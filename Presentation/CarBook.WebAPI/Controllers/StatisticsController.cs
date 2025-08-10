using CarBook.Application.Features.CQRS.Handlers.CarHandlers;
using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StatisticsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCarCount")]
        public IActionResult GetCarCount()
        {
            var values = _mediator.Send(new GetCarCountQuery()).Result;
            return Ok(values);
        }

        [HttpGet("GetLocationCount")]
        public IActionResult GetLocationCount()
        {
            var values = _mediator.Send(new GetLocationCountQuery()).Result;
            return Ok(values);
        }

        [HttpGet("GetAuthorCount")]
        public IActionResult GetAuthorCount()
        {
            var values = _mediator.Send(new GetAuthorCountQuery()).Result;
            return Ok(values);
        }

        [HttpGet("GetBlogCount")]
        public IActionResult GetBlogCount()
        {
            var values = _mediator.Send(new GetBlogCountQuery()).Result;
            return Ok(values);
        }

        [HttpGet("GetBrandCount")]
        public IActionResult GetBrandCount()
        {
            var values = _mediator.Send(new GetBrandCountQuery()).Result;
            return Ok(values);
        }

        [HttpGet("GetAvgRentPriceForDaily")]
        public IActionResult GetAvgRentPriceForDaily()
        {
            var values = _mediator.Send(new GetAvgRentPriceForDailyQuery()).Result;
            return Ok(values);
        }

        [HttpGet("GetAvgRentPriceForWeekly")]
        public IActionResult GetAvgRentPriceForWeekly()
        {
            var values = _mediator.Send(new GetAvgRentPriceForWeeklyQuery()).Result;
            return Ok(values);
        }

        [HttpGet("GetAvgRentPriceForMonthly")]
        public IActionResult GetAvgRentPriceForMonthly()
        {
            var values = _mediator.Send(new GetAvgRentPriceForMonthlyQuery()).Result;
            return Ok(values);
        }

        [HttpGet("GetCarCountByTransmissionAuto")]
        public IActionResult GetCarCountByTransmissionAuto()
        {
            var values = _mediator.Send(new GetCarCountByTransmissionAutoQuery()).Result;
            return Ok(values);
        }

        [HttpGet("GetBrandNameByMaxCar")]
        public IActionResult GetBrandNameByMaxCar()
        {
            var values = _mediator.Send(new GetBrandNameByMaxCarQuery()).Result;
            return Ok(values);
        }

        [HttpGet("GetBlogTitleByMaxBlogComment")]
        public IActionResult GetBlogTitleByMaxBlogComment()
        {
            var values = _mediator.Send(new GetBlogTitleByMaxBlogCommentQuery()).Result;
            return Ok(values);
        }

        [HttpGet("GetCarCountByKmLessThan1000")]
        public IActionResult GetCarCountByKmLessThan1000()
        {
            var values = _mediator.Send(new GetCarCountByKmLessThan1000Query()).Result;
            return Ok(values);
        }

        [HttpGet("GetCarCountByFuelGasolineOrDiesel")]
        public IActionResult GetCarCountByFuelGasolineOrDiesel()
        {
            var values = _mediator.Send(new GetCarCountByFuelGasolineOrDieselQuery()).Result;
            return Ok(values);
        }

        [HttpGet("GetCarCountByFuelElectric")]
        public IActionResult GetCarCountByFuelElectric()
        {
            var values = _mediator.Send(new GetCarCountByFuelElectricQuery()).Result;
            return Ok(values);
        }

        [HttpGet("GetCarBrandAndModelByRentPriceDailyMax")]
        public IActionResult GetCarBrandAndModelByRentPriceDailyMax()
        {
            var values = _mediator.Send(new GetCarBrandAndModelByRentPriceDailyMaxQuery()).Result;
            return Ok(values);
        }

        [HttpGet("GetCarBrandAndModelByRentPriceDailyMin")]
        public IActionResult GetCarBrandAndModelByRentPriceDailyMin()
        {
            var values = _mediator.Send(new GetCarBrandAndModelByRentPriceDailyMinQuery()).Result;
            return Ok(values);
        }
    }
}
