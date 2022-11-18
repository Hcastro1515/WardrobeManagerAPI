using AutoMapper.Configuration.Conventions;
using WardrobeManagerAPI.Entities;

namespace WardrobeManagerAPI.Services.WardrobeItemService
{
    public interface IWardrobeItemService
    {

        public List<WardrobeItem> WardrobeItems { get; set; }
        Task<List<WardrobeItem>?> GetAllWardrobeItemsForId(int wardrobeId); 
        Task<List<WardrobeItem>?> CreateWardrobeItemForId(WardrobeItem wItem,int wardrobeId);
        Task<WardrobeItem?> GetWardrobeItemById(int id);
        Task<List<WardrobeItem>?> UpdateWardrobeItemForId(WardrobeItem wItem, int wardrobeId);
        Task<bool>DeleteWardrobeItemForId(int wardrobeId);
    }
}
