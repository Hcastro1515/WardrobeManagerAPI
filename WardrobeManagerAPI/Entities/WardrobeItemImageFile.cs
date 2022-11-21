using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WardrobeManagerAPI.Entities
{
    [Table("WardrobeItemImageFile")]
    public class WardrobeItemImageFile
    {
        public int Id { get; set; }
        public string? FileName { get; set; }
        public string? StoredFileName { get; set; }
        public string? ContentType { get; set; }
    }
}
