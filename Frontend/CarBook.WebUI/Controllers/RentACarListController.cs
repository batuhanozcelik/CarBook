using CarBook.Dto.BrandDtos;
using CarBook.Dto.RentACarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarBook.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RentACarListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
           
            var bookPickDate = TempData["bookPickDate"];
            var bookOffDate = TempData["bookOffDate"];
            var timePick= TempData["timePick"];
            var timeOff = TempData["timeOff"];
            var locationId = TempData["locationId"];

            id = int.Parse(locationId.ToString());

            ViewBag.bookPickDate = bookPickDate;
            ViewBag.bookOffDate = bookOffDate;
            ViewBag.timePick = timePick;
            ViewBag.timeOff = timeOff;
            ViewBag.locationId = locationId;


            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7073/api/RentACars?locationId={id}&available=true");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<FilterRentACarDto>>(jsonData);
                return View(values);
            }
            return View();

          
        }
    }
}
