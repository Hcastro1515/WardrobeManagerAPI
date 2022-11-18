using System.ComponentModel.DataAnnotations;

namespace WardrobeManagerAPI.Entities
{
    public class WardrobeItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set;}
        public int WardrobeId { get; set; }
    }
}
