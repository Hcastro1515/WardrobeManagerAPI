using Microsoft.EntityFrameworkCore;
using WardrobeManagerAPI.Data;
using WardrobeManagerAPI.Entities;
using WardrobeManagerAPI.Services.WardrobeService.WardrobeService;

namespace WardrobeManagerAPI.Services.WardrobeService.WardrobeService
{
    public class WardrobeService : IWardrobeService
    {

        private readonly DataContext _context;
        public WardrobeService(DataContext context)
        {
            _context = context;
        }


        public List<Wardrobe> Wardrobes { get; set; } = new List<Wardrobe>();

        public async Task<List<Wardrobe>?> CreateWardrobe(Wardrobe w)
        {

            try
            {
                if (w != null)
                {
                    w.Items = null;
                    await _context.Wardrobes.AddAsync(w);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            return await GetAllWardrobes();
        }

        public async Task<List<Wardrobe>?> DeleteWardrobe(int Id)
        {

            try
            {
                var wardrobe = await _context.Wardrobes.FirstOrDefaultAsync(w => w.Id == Id);
                if (wardrobe != null)
                {
                    _context.Wardrobes.Remove(wardrobe);
                    await _context.SaveChangesAsync();
                }


            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            return await GetAllWardrobes();
        }

        public async Task<List<Wardrobe>?> GetAllWardrobes()
        {
            return await _context.Wardrobes.Include(w => w.Items).ToListAsync();
        }

        public async Task<Wardrobe?> GetWardrobyId(int Id)
        {
            Wardrobe? response = await _context.Wardrobes.Include(w => w.Items).FirstOrDefaultAsync(w => w.Id == Id);

            if (response == null) return null;

            return response;
        }

        public async Task LoadWardrobes()
        {
            Wardrobes = await _context.Wardrobes.ToListAsync();
        }

        public async Task<List<Wardrobe>?> UpdateWardrobe(Wardrobe w)
        {
            
            Wardrobe? wardrobe = await _context.Wardrobes.FirstOrDefaultAsync(w => w.Id == w.Id);
            try
            {
                if (wardrobe != null)
                {
                    wardrobe.Name = w.Name;
                    await _context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            return await GetAllWardrobes();
        }
    }
}
