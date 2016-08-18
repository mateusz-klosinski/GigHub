using GigHub.Core.Models;
using GigHub.Core.Repositories;
using System.Linq;

namespace GigHub.Persistance.Repositories
{
    public class FollowRepository : IFollowRepository
    {
        private readonly ApplicationDbContext _context;

        public FollowRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Follow GetFollowById(string followerId, string artistId)
        {
            return _context.Follows.SingleOrDefault(f => f.ArtistId == artistId && f.FollowerId == followerId);
        }

        public void AddFollow(Follow follow)
        {
            _context.Follows.Add(follow);
        }

        public void RemoveFollow(Follow follow)
        {
            _context.Follows.Remove(follow);
        }
    }
}