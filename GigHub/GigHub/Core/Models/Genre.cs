using System.ComponentModel.DataAnnotations;

namespace GigHub.Core.Models
{
    public class Genre
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }
    }
}