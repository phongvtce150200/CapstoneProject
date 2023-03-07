using B2Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvatarController : ControllerBase
    {
        readonly string accountId = "8cf21d9ed82f";
        readonly string applicationKey = "00586eaff88f6773222396833126d29d802de72a28";

        private readonly ILogger<AvatarController> _logger;

        public AvatarController(ILogger<AvatarController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                ModelState.AddModelError("file", "Please select a file to upload.");
            }
            // Create a new instance of the B2Client class and authorize it with your Backblaze account credentials
            var b2Client = new B2Client(accountId, applicationKey);
            var authResponse = await B2Client.AuthorizeAsync(accountId, applicationKey);

            using var memoryStream = new MemoryStream();
            var fileName = Path.GetFileName(file.FileName);
            await file.CopyToAsync(memoryStream);
            var fileBytes = memoryStream.ToArray();

            // Create a new instance of the B2BucketClient class to interact with a specific bucket
            var bucketClient = b2Client.Buckets;

            // Get the list of all buckets in the account and find the bucket with the specified name
            var buckets = await bucketClient.GetList();
            var bucket = buckets.FirstOrDefault(b => b.BucketName == "CapstoneProject");

            if (bucket == null)
            {
                ModelState.AddModelError("", "The specified bucket was not found.");
            }

            // Create a new instance of the B2FileClient class to interact with the files in the bucket
            var fileClient = b2Client.Files;

            string newFileName = "Avatar/newImage.jpg";

            // Upload the file to the bucket and get the download URL
            var uploadUrl = await fileClient.GetUploadUrl("f81cbf92c18d495e8d68021f");
            var uploadResult = await fileClient.Upload(fileBytes, newFileName, uploadUrl, uploadUrl.BucketId);
            // link hinh o day |v| lay cai nay luu vao DB
            var downloadUrl = $"{authResponse.DownloadUrl}/file/{bucket.BucketName}/{uploadResult.FileName}";

            return Ok(downloadUrl);
        }
    }
}
