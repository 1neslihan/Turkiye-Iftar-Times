using DataProvider.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;


namespace IftarSaati.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IftarSaatiController : ControllerBase
    {

        public string jsonData;
        public static List<Root> infoStorage = new List<Root>();
        private string apiKey = "your api key";



        [HttpGet]
        public IActionResult GetTime()
        {
            return Ok(infoStorage);
        }

        [HttpPost]
        public IActionResult GetSpesificTime(string city)
        {
            var client = new RestClient("https://api.collectapi.com");
            var request = new RestRequest($"pray/single?ezan=Ak%C5%9Fam&data.city={city}", Method.Get);
            request.AddHeader("authorization", apiKey);
            request.AddHeader("content-type", "application/json");
            RestResponse response = client.Execute(request);

            jsonData=response.Content;
            Root infos = JsonConvert.DeserializeObject<Root>(jsonData);
            infoStorage.Add(infos);

            return Ok(infos);

        }





    }
}
