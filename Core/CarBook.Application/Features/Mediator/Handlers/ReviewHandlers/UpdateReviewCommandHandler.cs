using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class UpdateReviewCommandHandler : IRequest<UpdateReviewCommand>
    {
        private readonly IRepository<Review> _repository;

        public UpdateReviewCommandHandler(IRepository<Review> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.ReviewId);
            value.CarId = request.CarId;
            value.Comment = request.Comment;
            value.CustomerImage = request.CustomerImage;
            value.CustomerName = request.CustomerName;
            value.RatingValue = request.RatingValue;
            value.ReviewDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            await _repository.UpdateAsync(value);
            
        }
    }
}
