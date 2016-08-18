using GigHub.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace GigHub.Persistance.EntityConfigurations
{
    public class FollowConfiguration : EntityTypeConfiguration<Follow>
    {
        public FollowConfiguration()
        {
            HasKey(f => new { f.FollowerId, f.ArtistId });

            Property(f => f.FollowerId)
                .HasColumnOrder(1);

            Property(f => f.ArtistId)
                .HasColumnOrder(2);

            HasRequired(f => f.Follower)
                .WithMany()
                .WillCascadeOnDelete(false);
        }
    }
}