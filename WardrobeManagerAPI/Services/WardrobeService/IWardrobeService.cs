using WardrobeManagerAPI.Entities;

namespace WardrobeManagerAPI.Services.WardrobeService.WardrobeService
{
    public interface IWardrobeService
    {
        List<Wardrobe> Wardrobes { get; set; }
        Task LoadWardrobes();
        Task<List<Wardrobe>?> GetAllWardrobes();
        Task<Wardrobe?> GetWardrobyId(int Id);
        Task<List<Wardrobe>?> CreateWardrobe(Wardrobe w);
        Task<List<Wardrobe>?> UpdateWardrobe(Wardrobe w);
        Task<List<Wardrobe>?> DeleteWardrobe(int Id);

    }
}
