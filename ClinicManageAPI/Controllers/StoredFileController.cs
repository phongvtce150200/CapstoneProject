using CG.Web.MegaApiClient;
using ClinicManageAPI.DTO;
using ClinicManageAPI.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoredFileController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public StoredFileController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public async Task<List<MegaIODTO>> GetListAsync(string folder)
        {
            var listFile = new List<MegaIODTO>();
            var megaClient = new MegaApiClient();

            await megaClient.LoginAsync(_configuration["MegaAPI:Email"], _configuration["MegaAPI:Password"]);

            IEnumerable<INode>? nodes = await megaClient.GetNodesAsync();

            var nodeFolder = nodes.SingleOrDefault(x => x.Type == NodeType.Directory && x.Name == folder);
            var nodeByFolder = await megaClient.GetNodesAsync(nodeFolder);
            var files = nodeByFolder.Where(x => x.Type == NodeType.File);

            foreach (var file in files)
            {
                var downloadUrl = await megaClient.GetDownloadLinkAsync(file);

                listFile.Add(new MegaIODTO()
                {
                    FileName = file.Name,
                    FileSize = FileHelper.ToFileSize(file.Size),
                    DownloadUrl = downloadUrl.ToString()
                });
            }

            return listFile;
        }
    }
}
