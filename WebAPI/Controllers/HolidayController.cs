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
using Microsoft.AspNetCore.Cors;

namespace WebAPI.Controllers
{
    [Route("api/holiday")]
    [ApiController]
    [AllowAnonymous]
    public class HolidayController : ControllerBase
    {
        private readonly IApplicationHoliday _IApplicationHoliday;
        private readonly IConfiguration _configuration;

        public HolidayController(IApplicationHoliday IApplicationHoliday, IConfiguration configuration)
        {
            _IApplicationHoliday = IApplicationHoliday;
            _configuration = configuration;
        }
                
        [Produces("application/json")]
        [HttpGet]
        public async Task<IActionResult> GetAPIHoliday()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {                    
                    string apiUrl = _configuration["AppSettings:ApiUrl"];

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
        
        [Produces("application/json")]
        [HttpGet("GetHoliday")]
        public async Task<IActionResult> GetHoliday()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var result = await _IApplicationHoliday.Get();

                    return Ok(result);
                }
                catch (HttpRequestException ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
        }

        [Produces("application/json")]
        [HttpGet("DelHoliday/{id}")]
        public async Task<IActionResult> DelHoliday(int id)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    await _IApplicationHoliday.Del(id);

                    return Ok();
                }
                catch (HttpRequestException ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
        }




    }
}
