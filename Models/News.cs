using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace News_Backend.Models
{
    public class News : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [ForeignKey("Categories")]
        public int CategoryId { get; set; }
    }
}
