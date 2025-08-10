using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetCarCountByTransmissionIsAutoQueryHandler : IRequestHandler<GetCarCountByTransmissionAutoQuery,GetCarCountByTransmissionAutoQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarCountByTransmissionIsAutoQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountByTransmissionAutoQueryResult> Handle(GetCarCountByTransmissionAutoQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarCountByTransmissionIsAuto();
            return new GetCarCountByTransmissionAutoQueryResult
            {
                CarCountByTransmissionAuto = value,
            };
        }
    }
}
