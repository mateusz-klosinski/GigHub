using GigHub.Core.Models;
using GigHub.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace GigHub.Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<ApplicationUser> GetArtistsFollowedByUser(string userId)
        {
            return _context.Follows
                .Where(f => f.FollowerId == userId)
                .Select(f => f.Artist)
                .ToList();
        }

        public bool CheckIfArtistIsFollowed(string userId, Gig gig)
        {
            return _context.Follows.Any(f => f.FollowerId == userId && gig.ArtistId == f.ArtistId);
        }


        public string GetUserIdByName(string name)
        {
            return _context.Users.Single(u => u.Name == name).Id;
        }
    }
}