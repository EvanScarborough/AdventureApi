using System;
using System.Collections.Generic;
using System.Linq;
using adventureApi.Models.Entities;
using adventureApi.Models.RequestModels;
using adventureApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace adventureApi.Services
{
    public class AdventureService : IAdventureService
    {
        private AdventureContext _db;
        private IImageService _imageService;

        public static readonly string ImageBlobFolder = "adventure";

        public AdventureService(AdventureContext db, IImageService imageService)
        {
            _db = db;
            _imageService = imageService;
        }

        public Adventure Get(int adventureId)
        {
            return _db.Adventures
                .Where(a => a.AdventureId == adventureId)
                .Include(a => a.AddedByUser)
                .Include(a => a.AdventureMembers)
                .ThenInclude(am => am.User)
                .Include(a => a.AdventureMembers)
                .ThenInclude(am => am.AdventureImages)
                .SingleOrDefault();
        }

        public List<Adventure> GetAllByLocationId(int locationId)
        {
            return _db.Adventures
                .Where(a => a.LocationId == locationId)
                .Where(a => !a.IsDeleted)
                .Include(a => a.AddedByUser)
                .Include(a => a.AdventureMembers)
                .ThenInclude(am => am.User)
                .Include(a => a.AdventureMembers)
                .ThenInclude(am => am.AdventureImages)
                .ToList();
        }

        public bool UserHasAccess(Adventure adventure, int userId)
        {
            return !adventure.IsPrivate || adventure.AdventureMembers.Any(am => am.UserId == userId);
        }

        public Adventure Add(AddAdventureRequestModel request, int userId)
        {
            Adventure adventure = new Adventure()
            {
                Time = request.Time,
                LocationId = request.LocationId,
                Description = request.Description,
                AddedByUserId = userId,
                AddedAtTime = DateTime.UtcNow,
                IsPrivate = request.IsPrivate,
                IsDeleted = false
            };
            _db.Adventures.Add(adventure);
            _db.SaveChanges();
            _db.AdventureMembers.Add(new AdventureMember()
            {
                AdventureId = adventure.AdventureId,
                UserId = userId,
                Comment = request.Comment,
                Rating = request.Rating,
                IsCompleted = true,
                IsPrimary = true,
                IsPrivate = false,
                IsDeleted = false
            });
            foreach (var member in request.Members)
            {
                _db.AdventureMembers.Add(new AdventureMember()
                {
                    AdventureId = adventure.AdventureId,
                    UserId = member.UserId,
                    Comment = "",
                    Rating = 0,
                    IsCompleted = false,
                    IsPrimary = false,
                    IsPrivate = false,
                    IsDeleted = false
                });
            }
            _db.SaveChanges();
            return adventure;
        }

        public void AddReview(int adventureId, AdventureReviewRequestModel request, int userId)
        {
            var adventure = Get(adventureId);
            var member = adventure.AdventureMembers.Where(m => m.UserId == userId).SingleOrDefault();
            if (member == null) throw new Exception("The user was not part of this adventure");
            member.Rating = request.Rating;
            member.Comment = request.Comment;
            member.IsCompleted = true;
            _db.SaveChanges();
        }

        public AdventureImage AddImage(int adventureId, int userId, IFormFile file)
        {
            var adventure = Get(adventureId);
            var member = adventure.AdventureMembers.Where(m => m.UserId == userId).SingleOrDefault();
            if (member == null) throw new Exception("The user was not part of this adventure");
            var fileUrl = _imageService.UploadToBlobStorage(file, ImageBlobFolder);
            var adventureImage = new AdventureImage()
            {
                AdventureMemberId = member.AdventureMemberId,
                ImageUrl = fileUrl
            };
            _db.AdventureImages.Add(adventureImage);
            _db.SaveChanges();
            return adventureImage;
        }
    }
}
