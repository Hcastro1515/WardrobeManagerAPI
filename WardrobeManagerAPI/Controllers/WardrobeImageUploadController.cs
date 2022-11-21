using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WardrobeManagerAPI.Data;
using WardrobeManagerAPI.Entities;

namespace WardrobeManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WardrobeImageUploadController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _env;

        public WardrobeImageUploadController(DataContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpPost]
        public async Task<ActionResult<IList<UploadResult>>> UploadImage(IFormFile file)
        {

            var uploadResult = new UploadResult();
            string trustedFileNameForFileStorage;
            var untrustedFileName = file.Name; 
            uploadResult.FileName = untrustedFileName;
            var trustedFileNameForDisplay = WebUtility.HtmlEncode(untrustedFileName);


            trustedFileNameForFileStorage = Path.GetRandomFileName();
            var path = Path.Combine(_env.ContentRootPath, "uploads", trustedFileNameForFileStorage);

            await using FileStream fs = new(path, FileMode.Create); 
            await file.CopyToAsync(fs);

            uploadResult.StoredFileName = trustedFileNameForFileStorage;
            uploadResult.Uploaded = true;
            
            //Store file info in databse
            WardrobeItemImageFile imageUpload = new WardrobeItemImageFile();
            imageUpload.FileName = untrustedFileName;
            imageUpload.StoredFileName = trustedFileNameForDisplay;
            imageUpload.ContentType = file.ContentType;

            _context.ItemImages.Add(imageUpload); 
            
            await _context.SaveChangesAsync();

            return Ok(uploadResult); 

        }

    }
}
