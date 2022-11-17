using WardrobeManagerAPI.Entities;

namespace WardrobeManagerAPI.Services.WardrobeService.WardrobeService
{
    public interface IWardrobeService
    {
        List<Wardrobe> Wardrobes { get; set; }
        List<WardrobeItem> WardrobeItems { get; set; }
        Task LoadWardrobes();
        Task LaodWardrobeItems();
        Task<List<Wardrobe>?> GetAllWardrobes();
        Task<Wardrobe?> GetWardrobyId(int Id);
        Task<List<Wardrobe>?> CreateWardrobe(Wardrobe w);
        Task<List<Wardrobe>?> UpdateWardrobe(Wardrobe w);
        Task<List<Wardrobe>?> DeleteWardrobe(int Id);

    }
}
