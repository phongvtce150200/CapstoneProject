using ClinicManageAPI.Respone;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClinicManageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpPost("CheckAlzheimerDisease")]
        public async Task<IActionResult> CheckAlzheimer(IFormFile file)
        {
            using (var client = new HttpClient())
            {
                // Set the base URL for the API endpoint
                client.BaseAddress = new Uri("http://localhost:8000");

                // Create a new multipart/form-data content to send the file
                var content = new MultipartFormDataContent();
                var fileContent = new StreamContent(file.OpenReadStream());
                content.Add(fileContent, "file", file.FileName);

                // Send the POST request to the /predict endpoint
                var response = await client.PostAsync("/predict", content);

                // Read the JSON response from the API and parse it into a dictionary
                var responseJson = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<PredictionResponse>(responseJson);

                // Return the percentage as a JSON response
                return Ok(result);
            }
        }

    }
}
