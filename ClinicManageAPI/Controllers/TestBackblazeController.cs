using B2Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace ClinicManageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestBackblazeController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile Uploadfile)
        {
            using (var memoryStream = new MemoryStream())
            {
                await Uploadfile.CopyToAsync(memoryStream);
                var fileBytes = memoryStream.ToArray();
                var client = new B2Client("8cf21d9ed82f", "00586eaff88f6773222396833126d29d802de72a28");
                var uploadUrl = await client.Files.GetUploadUrl("f81cbf92c18d495e8d68021f");
                var file = await client.Files.Upload(fileBytes, Uploadfile.FileName, uploadUrl,uploadUrl.BucketId); 
            }
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetInfoFile(string id)
        {
            var client = new B2Client("8cf21d9ed82f", "00586eaff88f6773222396833126d29d802de72a28");
            var file = client.Files.GetFriendlyDownloadUrl("26 (20).jpg", "CapstoneProject");
            return Ok(file);
        }
    }
}
