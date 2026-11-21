using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {


        private readonly HttpClient _httpClient;

        public ValuesController(IHttpClientFactory factory) {


            _httpClient = factory.CreateClient("ai");
        
        
        }


        [HttpPost]
        public async Task<IActionResult> Predict([FromBody] PredictIn predict)

        {   

            var result = await _httpClient.PostAsJsonAsync("/predict", predict);

            if (!result.IsSuccessStatusCode)


            {

                return StatusCode((int)result.StatusCode, await result.Content.ReadAsStringAsync());


            }


            var prediction = await result.Content.ReadFromJsonAsync<PredictOut>();

            return Ok(prediction);

        // GET: api/<ValuesController>

        }
            
            
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<ValuesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<ValuesController>
     

        //// PUT api/<ValuesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ValuesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
