using System.Collections.Generic;
using System.Linq;
using GigHub.Core.Models;
using GigHub.Core.Repositories;

namespace GigHub.Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext _context)
        {
            this._context = _context;
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
    }
}