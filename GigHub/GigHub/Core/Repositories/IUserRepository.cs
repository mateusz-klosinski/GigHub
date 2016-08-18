using GigHub.Core.Models;
using System.Collections.Generic;

namespace GigHub.Core.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<ApplicationUser> GetArtistsFollowedByUser(string userId);
        bool CheckIfArtistIsFollowed(string userId, Gig gig);
        string GetUserIdByName(string name);
    }
}