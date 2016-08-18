using System.Collections.Generic;
using GigHub.Core.Models;

namespace GigHub.Core.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<ApplicationUser> GetArtistsFollowedByUser(string userId);
        bool CheckIfArtistIsFollowed(string userId, Gig gig);
    }
}