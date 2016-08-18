using GigHub.Core.Models;

namespace GigHub.Core.Repositories
{
    public interface IFollowRepository
    {
        Follow GetFollowById(string followerId, string artistId);
        void AddFollow(Follow follow);
        void RemoveFollow(Follow follow);
    }
}