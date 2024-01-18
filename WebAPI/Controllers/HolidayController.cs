using Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using Entity.Entity;
using ViewModel.Holiday;
using Newtonsoft.Json;

namespace WebAPI.Controllers
{
    [Route("api/holiday")]
    [ApiController]
    public class HolidayController : ControllerBase
    {
        private readonly IApplicationHoliday _IApplicationHoliday;
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        public HolidayController(IApplicationHoliday IApplicationHoliday)
        {
            _IApplicationHoliday = IApplicationHoliday;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpGet]
        public async Task<IActionResult> GetAPIHoliday()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {                    
                    string apiUrl = "https://dadosbr.github.io/feriados/nacionais.json";
                                        
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();

                        var result = JsonConvert.DeserializeObject<List<ViewModelHoliday>>(content);


                        await _IApplicationHoliday.Set(result);

                        return Ok(result);
                        //};
                    }
                    else
                    {                        
                        return StatusCode((int)response.StatusCode, "Erro na requisição à API externa");
                    }
                }
                catch (HttpRequestException ex)
                {                    
                    return StatusCode(500, $"Erro na requisição à API externa: {ex.Message}");
                }
            }
        }




    }
}
