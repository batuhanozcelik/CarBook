using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingWithTimePeriodQueryHandler : IRequestHandler<GetCarPricingWithTimePeriodQuery, List<GetCarPricingWithTimePeriodQueryResult>>
    {
        private readonly ICarPricingRepository _repository;

        public GetCarPricingWithTimePeriodQueryHandler(ICarPricingRepository repository)
        {
            _repository = repository;
        }

        public  async Task<List<GetCarPricingWithTimePeriodQueryResult>> Handle(GetCarPricingWithTimePeriodQuery request, CancellationToken cancellationToken)
        {
            var carPricings = _repository.GetCarPricingWithTimePeriod();

            return carPricings
                .GroupBy(x=> new {x.Car.CarId, x.Car.Model, BrandName= x.Car.Brand.Name, CoverImage=x.Car.CoverImageUrl})
                .Select(y=> new GetCarPricingWithTimePeriodQueryResult
                {
                    CarId=y.Key.CarId,
                    Model=y.Key.Model,
                    BrandName=y.Key.BrandName,
                    CoverImage = y.Key.CoverImage,
                    DailyAmount = y.FirstOrDefault(p=> p.PricingId==3)?.Amount??0,
                    WeeklyAmount=y.FirstOrDefault(p => p.PricingId == 4)?.Amount ?? 0,
                    MonthlyAmount= y.FirstOrDefault(p => p.PricingId == 6)?.Amount ?? 0,

                }).ToList();
        }
    }
}
