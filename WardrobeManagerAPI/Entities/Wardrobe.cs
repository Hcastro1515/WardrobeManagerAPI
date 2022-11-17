using System.ComponentModel.DataAnnotations;

namespace WardrobeManagerAPI.Entities
{
    public class Wardrobe
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public List<WardrobeItem>? Items { get; set; }

    }
}
