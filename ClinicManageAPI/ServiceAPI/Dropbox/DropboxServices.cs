using ClinicManageAPI.DTO;
using Dropbox.Api;
using Dropbox.Api.Files;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ClinicManageAPI.ServiceAPI.Dropbox
{
    public class DropboxServices
    {
        private static string refresh_token = "6GdhOCGUy6kAAAAAAAAAAeai3UJQHfnut16MeFWyCB4rUwPrsa-Emcdfff7B3VRO";
        private static string access_token = "sl.BYpLmszA_ywOGd-xuU12n7jONsjxwrXra-JvIN0dqkZymTAaiw-ybYrc_AQQlsyCQvIiYJphAt_VDYFONSJQmNjYscsbeJ7V0zK3mtEO-O5aVLRdb7FfIAkjfFaCXWg5P0XZ5b1yhQkA";
            
        DropboxClient client;
        string appKey = "90cw416qv0mcq71";
        string appSerect = "qoox1kc4fnoj9uh";

        public DropboxServices()
        {
            var config = new DropboxClientConfig();
            client = new DropboxClient(access_token, refresh_token, appKey, appSerect, config);
        }

        [HttpGet("GetShareLink")]
        public async Task<string> GetShareLinkAsync(string path)
        {

            try
            {
                var shareLinks = await client.Sharing.ListSharedLinksAsync(path: path);
                if (shareLinks.Links.Count > 0)
                {
                    string url = shareLinks.Links[0].Url;
                    return url;
                }
                else
                {
                    var shareLink = await client.Sharing.CreateSharedLinkWithSettingsAsync(path);
                    return shareLink.Url;
                }
            }
            catch (Exception)
            {

            }

            return null;
        }

        [HttpPost("Upload")]
        public async Task<DropBoxUploadResult> UploadAsync(IFormFile file, string filename)
        {
            try
            {
                Stream stream = file.OpenReadStream();
                FileMetadata result = await client.Files
                    .UploadAsync("/" + filename, mode: WriteMode.Overwrite.Instance, body: stream);

                string path = result.PathDisplay;
                string url = await GetShareLinkAsync(path);

                stream.Dispose();

                return new DropBoxUploadResult()
                {
                    UploadPath = path,
                    TemporraryURL = url,
                };

            }
            catch (Exception)
            {
                throw new Exception("Something went wrong: Upload error!");
            }
        }

    }
}
