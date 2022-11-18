using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WardrobeManagerAPI.Entities;
using WardrobeManagerAPI.Services.WardrobeItemService;

namespace WardrobeManagerAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WardrobeItemController : ControllerBase
    {
        private readonly IWardrobeItemService _wardrobeItemService; 
        public WardrobeItemController(IWardrobeItemService wardrobeItemService) {
            _wardrobeItemService = wardrobeItemService;
        }

        [HttpPost]
        public async Task<ActionResult<List<WardrobeItem>>> CreateItemForId([FromBody] WardrobeItem wItem, int id)
        {
            var items = await _wardrobeItemService.CreateWardrobeItemForId(wItem, id); 
            if(items != null)
            {
                return Ok(items);
            }else
            {
                return BadRequest("There was an Issue adding the Item"); 
            }

        }
    }
}
