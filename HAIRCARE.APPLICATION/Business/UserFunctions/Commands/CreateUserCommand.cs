using HAIRCARE.APPLICATION.Base.Interfaces;
using HAIRCARE.CORE.BaseEnumeration;
using HAIRCARE.CORE.BusinessDomain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace HAIRCARE.APPLICATION.Business.UserFunctions.Commands
{
    public class CreateUserCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AvatarImg { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int UserRoleId { get; set; }
        public string TimezoneId { get; set; }
        public string Language { get; set; }
        public List<int> GroupIds { get; set; }

        public CreateUserCommand()
        {
            GroupIds = new List<int>();
        }
    }
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IPasswordServices _passwordService;

        public CreateUserCommandHandler(IApplicationDbContext context, IPasswordServices passwordService)
        {
            _context = context;
            _passwordService = passwordService;
        }
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.Username,
                Password = _passwordService.HashPassword(request.Password),
                PasswordExpirationDate = DateTime.UtcNow.AddDays(90),
                Email = request.Email,
                UserRoleId = request.UserRoleId,
                TimezoneId = "",
                Language = "vi-VN",
                UserState = UserState.Temporary
            };
            _context.Users.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
