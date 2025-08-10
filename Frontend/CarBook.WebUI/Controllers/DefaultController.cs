using CarBook.Dto.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private IHttpClientFactory _httpClientFactory;
        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7073/api/Locations");
           
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
            List<SelectListItem> itemValues = (from x in values
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.LocationId.ToString(),
                                               }).ToList();

            ViewBag.v = itemValues;
                return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string bookPickDate, string bookOffDate,string timePick , string timeOff ,string locationId)
        {
            TempData["bookPickDate"]= bookPickDate;
            TempData["bookOffDate"]= bookOffDate;
            TempData["timePick"]= timePick;
            TempData["timeOff"]= timeOff;
            TempData["locationId"]= locationId;

            return RedirectToAction("Index","RentACarList");
        }
    }
}
