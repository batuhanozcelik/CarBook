using CarBook.Dto.CarPricingDtos;
using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardCarPricingListComponentPartial : ViewComponent
    {
        private IHttpClientFactory _httpClientFactory;
        public _AdminDashboardCarPricingListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            ViewBag.v1 = "Fiyatlar";
            ViewBag.v2 = "Araç Fiyat Paketleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7073/api/CarPricings/GetCarPricingWithCarList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarPricingListWithBrandAndModelDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
