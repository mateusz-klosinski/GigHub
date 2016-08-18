namespace GigHub.Core.Models
{
    public class Follow
    {
        public ApplicationUser Follower { get; set; }

        public ApplicationUser Artist { get; set; }

        public string FollowerId { get; set; }

        public string ArtistId { get; set; }
    }
}