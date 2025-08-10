using CarBook.Dto.AboutDtos;
using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/AdminStatistics")]
    public class AdminStatisticsController : Controller
    {
        private IHttpClientFactory _httpClientFactory;
        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            #region CarCount
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7073/api/Statistics/GetCarCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var valueCarCount = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.carCount = valueCarCount.CarCount;
            }
            #endregion

            #region LocationCount
            var responseMessage2 = await client.GetAsync("https://localhost:7073/api/Statistics/GetLocationCount");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var valueLocationCount = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData2);
                ViewBag.locationCount = valueLocationCount.LocationCount;
            }
            #endregion

            #region AuthorCount
            var responseMessage3 = await client.GetAsync("https://localhost:7073/api/Statistics/GetAuthorCount");
            if (responseMessage3.IsSuccessStatusCode)
            {
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var valueAuthorCount = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData3);
                ViewBag.authorCount = valueAuthorCount.AuthorCount;
            }
            #endregion

            #region BlogCount
            var responseMessage4 = await client.GetAsync("https://localhost:7073/api/Statistics/GetBlogCount");
            if (responseMessage4.IsSuccessStatusCode)
            {
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                var valueBlogCount = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData4);
                ViewBag.blogCount = valueBlogCount.BlogCount;
            }
            #endregion

            #region BrandCount
            var responseMessage5 = await client.GetAsync("https://localhost:7073/api/Statistics/GetBrandCount");
            if (responseMessage5.IsSuccessStatusCode)
            {
                var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
                var valueBrandCount = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData5);
                ViewBag.brandCount = valueBrandCount.BrandCount;
            }
            #endregion

            #region AvgRentPriceForDaily
            var responseMessage6 = await client.GetAsync("https://localhost:7073/api/Statistics/GetAvgRentPriceForDaily");
            if (responseMessage6.IsSuccessStatusCode)
            {
                var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
                var valueAvgRentPriceForDaily = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData6);
                ViewBag.avgRentPriceForDaily = valueAvgRentPriceForDaily.AvgPriceForDaily.ToString("0,00");
            }
            #endregion

            #region AvgRentPriceForWeekly
            var responseMessage7 = await client.GetAsync("https://localhost:7073/api/Statistics/GetAvgRentPriceForWeekly");
            if (responseMessage7.IsSuccessStatusCode)
            {
                var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
                var valueAvgRentPriceForWeekly = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData7);
                ViewBag.avgRentPriceForWeekly = valueAvgRentPriceForWeekly.AvgPriceForWeekly.ToString("0,00");
            }
            #endregion

            #region AvgRentPriceForMonthly
            var responseMessage8 = await client.GetAsync("https://localhost:7073/api/Statistics/GetAvgRentPriceForMonthly");
            if (responseMessage8.IsSuccessStatusCode)
            {
                var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
                var valueAvgRentPriceForMonthly = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData8);
                ViewBag.avgRentPriceForMonthly = valueAvgRentPriceForMonthly.AvgPriceForMonthly.ToString("0,00");
            }
            #endregion

            #region CarCountByTransmissionAuto
            var responseMessage9 = await client.GetAsync("https://localhost:7073/api/Statistics/GetCarCountByTransmissionAuto");
            if (responseMessage9.IsSuccessStatusCode)
            {
                var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
                var valueCarCountByTransmissionAuto = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData9);
                ViewBag.carCountByTransmissionAuto = valueCarCountByTransmissionAuto.CarCountByTransmissionAuto;
            }
            #endregion

            #region CarCountByKmLessThan1000
            var responseMessage10 = await client.GetAsync("https://localhost:7073/api/Statistics/GetCarCountByKmLessThan1000");
            if (responseMessage10.IsSuccessStatusCode)
            {
                var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
                var valueCarCountByKmLessThan1000 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData10);
                ViewBag.carCountByKmLessThan1000 = valueCarCountByKmLessThan1000.CarCountByKmLessThan1000;
            }
            #endregion

            #region CarCountByFuelGasolineOrDiesel
            var responseMessage11 = await client.GetAsync("https://localhost:7073/api/Statistics/GetCarCountByFuelGasolineOrDiesel");
            if (responseMessage11.IsSuccessStatusCode)
            {
                var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
                var valueCarCountByFuelGasolineOrDiesel = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData11);
                ViewBag.carCountByFuelGasolineOrDiesel = valueCarCountByFuelGasolineOrDiesel.CarCountByFuelGasolineOrDiesel;
            }
            #endregion

            #region CarCountByFuelElectric
            var responseMessage12 = await client.GetAsync("https://localhost:7073/api/Statistics/GetCarCountByFuelElectric");
            if (responseMessage12.IsSuccessStatusCode)
            {
                var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
                var valueCarCountByFuelElectric = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData12);
                ViewBag.carCountByFuelElectric = valueCarCountByFuelElectric.CarCountByFuelElectric;
            }
            #endregion

            #region CarBrandAndModelByRentPriceDailyMax
            var responseMessage13 = await client.GetAsync("https://localhost:7073/api/Statistics/GetCarBrandAndModelByRentPriceDailyMax");
            if (responseMessage13.IsSuccessStatusCode)
            {
                var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
                var valueCarBrandAndModelByRentPriceDailyMax = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData13);
                ViewBag.carBrandAndModelByRentPriceDailyMax = valueCarBrandAndModelByRentPriceDailyMax.CarBrandAndModelByRentPriceDailyMax;
            }
            #endregion

            #region CarBrandAndModelByRentPriceDailyMin
            var responseMessage14 = await client.GetAsync("https://localhost:7073/api/Statistics/GetCarBrandAndModelByRentPriceDailyMin");
            if (responseMessage14.IsSuccessStatusCode)
            {
                var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
                var valueCarBrandAndModelByRentPriceDailyMin = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData14);
                ViewBag.carBrandAndModelByRentPriceDailyMin = valueCarBrandAndModelByRentPriceDailyMin.CarBrandAndModelByRentPriceDailyMin;
            }
            #endregion

            #region BrandNameByMaxCar
            var responseMessage15 = await client.GetAsync("https://localhost:7073/api/Statistics/GetBrandNameByMaxCar");
            if (responseMessage15.IsSuccessStatusCode)
            {
                var jsonData15 = await responseMessage15.Content.ReadAsStringAsync();
                var valueBrandNameByMaxCar = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData15);
                ViewBag.brandNameByMaxCar = valueBrandNameByMaxCar.BrandNameByMaxCar;
            }
            #endregion

            #region BrandNameByMaxCar
            var responseMessage16 = await client.GetAsync("https://localhost:7073/api/Statistics/GetBlogTitleByMaxBlogComment");
            if (responseMessage16.IsSuccessStatusCode)
            {
                var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();
                var valueBlogTitleByMaxBlogComment = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData16);
                ViewBag.blogTitleByMaxBlogComment = valueBlogTitleByMaxBlogComment.BlogTitleByMaxBlogComment;
            }
            #endregion


            return View();
        }
    }
}
