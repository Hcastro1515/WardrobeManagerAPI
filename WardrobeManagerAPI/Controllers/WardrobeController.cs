using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WardrobeManagerAPI.Entities;
using WardrobeManagerAPI.Services.WardrobeService.WardrobeService;

namespace WardrobeManagerAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WardrobeController : ControllerBase
    {
        private readonly IWardrobeService _wardrobeService; 
        public WardrobeController(IWardrobeService wardrobeService)
        {
            _wardrobeService = wardrobeService;
        }


        [HttpGet]
        public async Task<ActionResult<List<Wardrobe>>> GetWardrobes()
        {
            var wardrobes = await _wardrobeService.GetAllWardrobes(); 
            
            if(wardrobes != null)
            {
                return Ok(wardrobes); 
            } else
            {
                return NotFound("Sorry, no wardrobes available :/");
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<Wardrobe>>> AddWardrobe([FromBody] Wardrobe w)
        {
            var wardrobe = await _wardrobeService.GetWardrobyId(w.Id);
            if (wardrobe != null)
            {
                return BadRequest("Item already exists"); 
            } else
            {
                await _wardrobeService.CreateWardrobe(w);
            }
               
            return Ok(await _wardrobeService.GetAllWardrobes());
        }

        [HttpPut]
        public async Task<ActionResult<List<Wardrobe>>> UpdateWardrobe([FromBody] Wardrobe w)
        {
            var wardrobe = await _wardrobeService.GetWardrobyId(w.Id); 
            try
            {
                if(wardrobe != null)
                {
                    await _wardrobeService.UpdateWardrobe(w);
                }else
                {
                    return NotFound("Item doesn't exist");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }   
            
            return Ok(await _wardrobeService.GetAllWardrobes());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Wardrobe>>> DeleteWardrobe(int Id)
        {
            var wardrobe = await _wardrobeService.GetWardrobyId(Id);

            try
            {
                if (wardrobe != null)
                    await _wardrobeService.DeleteWardrobe(Id);
                else
                    return NotFound("Item doesn't exist");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            return Ok(await _wardrobeService.GetAllWardrobes());
        }
    }
}
