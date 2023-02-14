using CG.Web.MegaApiClient;
using ClinicManageAPI.DTO;
using ClinicManageAPI.Helper;
using ClinicManageAPI.ServiceAPI.Dropbox;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoredFileController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        DropboxServices services = new DropboxServices();

        public StoredFileController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("GetShareLink")]
        public async Task<IActionResult> GetShareLinkAsync(string path)
        {
            string url = await services.GetShareLinkAsync(path);
            return Ok(url);
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            DropBoxUploadResult obj = await services.UploadAsync(file, file.FileName);
            return Ok(obj);

        }


    }
}
