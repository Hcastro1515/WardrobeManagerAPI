using AutoMapper.Configuration.Conventions;
using WardrobeManagerAPI.Entities;

namespace WardrobeManagerAPI.Services.WardrobeItemService
{
    public interface IWardrobeItemService
    {

        public List<WardrobeItem> WardrobeItems { get; set; }
        Task<List<WardrobeItem>?> GetAllWardrobeItemsForId(int WardrobeId); 
        Task<List<WardrobeItem>?> CreateWardrobeItemForId(WardrobeItem wItem,int WardrobeId);
        Task<WardrobeItem?> GetWardrobeItemById(int id);
        Task<List<WardrobeItem>?> UpdateWardrobeItemForId(WardrobeItem wItem, int WardrobeId);
        Task<List<WardrobeItem>?> DeleteWardrobeItemForId(WardrobeItem wItem, int WardrobeId);


    }
}
