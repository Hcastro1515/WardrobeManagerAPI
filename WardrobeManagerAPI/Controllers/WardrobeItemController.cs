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


        [HttpGet]
        public async Task<ActionResult<List<WardrobeItem>>?> GetAllWardrobeItemsForId(int wardrobeId) {
            
                var items = await _wardrobeItemService.GetAllWardrobeItemsForId(wardrobeId);
            if (items != null)
                return Ok(items);
            else if (items == null)
                return NotFound("Items not found or doesn't exists");
            else
                return BadRequest("There was an issue getting the data, please try again"); 
            
        }

        [HttpGet]
        public async Task<ActionResult<WardrobeItem>?> GetWardrobeItemById(int id)
        {
            var item = await _wardrobeItemService.GetWardrobeItemById(id);
            if (item != null) 
                return Ok(item);
            else if (item == null) 
                return NotFound("Item was not found");
            else 
                return BadRequest("There was an issue getting the requested item"); 
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

        [HttpPut]
        public async Task<ActionResult<List<WardrobeItem>>?> UpdateWardrobeItem([FromBody] WardrobeItem w)
        {
            if (w == null) return BadRequest("Wardrobe Item cannot be null"); 
            
            var items = await _wardrobeItemService.UpdateWardrobeItemForId(w, w.WardrobeId);
            return Ok(items);

        }

        [HttpDelete]
        public async Task<ActionResult<List<WardrobeItem>>?> DeleteWardrobeItem(int id)
        {
           bool deleted = await _wardrobeItemService.DeleteWardrobeItemForId(id);

            if (deleted)
                return Ok("Item was successfully deleted");
            else if(!deleted)
                return NotFound("The item you are trying to delete doesn't exist");
            else
                return BadRequest("There was an issue deleting the item");
        }
    }
}

