using CarBook.Application.Enums;
using CarBook.Application.Features.Mediator.Commands.AppUserCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand>
    {
        private readonly IRepository<AppUser> _appUserRepository;

        public CreateAppUserCommandHandler(IRepository<AppUser> appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }

        public async Task Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            var values = _appUserRepository.CreateAsync(new AppUser
            {
                Password = request.Password,
                Username = request.Username,
                AppRoleId = (int)UserRolesType.Member,
                Email=request.Email,
                Name=request.Name,
                Surname=request.Surname
            });
        }
    }
}
