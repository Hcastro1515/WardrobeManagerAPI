using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using WardrobeManagerAPI.Data;
using WardrobeManagerAPI.Entities;
using WardrobeManagerAPI.Services.WardrobeService.WardrobeService;

namespace WardrobeManagerAPI.Services.WardrobeItemService
{
    public class WardrobeItemService : IWardrobeItemService
    {
        private readonly DataContext _context;
        private readonly IWardrobeService _wardrobeService; 
        public List<WardrobeItem> WardrobeItems { get; set; } = new List<WardrobeItem>();

        public WardrobeItemService(DataContext context, IWardrobeService wardrobeService)
        {
            _context = context;
            _wardrobeService = wardrobeService;
        } 
        
        public async Task<List<WardrobeItem>?> CreateWardrobeItemForId(WardrobeItem wItem, int wardrobeId)
        {
            //Check if item doesn't exist in Database
            var item = await GetWardrobeItemById(wItem.Id);
            //Get Wardrobe for passed Id
            Wardrobe? wardrobe = await _wardrobeService.GetWardrobyId(wardrobeId);

            try
            {
                //If wardrobe doesnt exits return null
                //If item already exist return null
                if (wardrobe == null || item != null) return null; 
                
                await _context.WardrobeItems.AddAsync(wItem);
                wardrobe?.Items?.Add(wItem);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex )
            {
                Console.Error.WriteLine(ex.Message); 
                throw;
            }

            return await GetAllWardrobeItemsForId(wardrobeId);

        }

        public async Task<bool> DeleteWardrobeItemForId(int itemId)
        {
            bool deleted = false; 
            //Check if item exist
            var item = await GetWardrobeItemById(itemId); 

            if(item != null )
            {
                _context.Remove(item); 
                await _context.SaveChangesAsync();
                deleted = true;
            } else
            {
                return false; 
            }

            return deleted;
        }

        public async Task<List<WardrobeItem>?> GetAllWardrobeItemsForId(int id)
        {
            var items = await _context.WardrobeItems.Where(i => i.WardrobeId == id).ToListAsync();
            
            if(items.Count == 0) return null;
            
            return items; 
        }

        public async Task<WardrobeItem?> GetWardrobeItemById(int id)
        {
            var item = await _context.WardrobeItems.FirstOrDefaultAsync(i => i.Id == id);
            if (item == null) return null; 
            return item;
        }

        public async Task<List<WardrobeItem>?> UpdateWardrobeItemForId(WardrobeItem wItem, int wardrobeId)
        {
            //check if item exist
            WardrobeItem? item =  await GetWardrobeItemById(wItem.Id); 

            
            if(item != null)
            {
                item.Name = wItem.Name;
                item.Description = wItem.Description;   
                await _context.SaveChangesAsync();
            }
            
            return await GetAllWardrobeItemsForId(wardrobeId);

        }
    }
}
