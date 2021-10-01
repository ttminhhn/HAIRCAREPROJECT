using HAIRCARE.APPLICATION.Base.Exceptions;
using HAIRCARE.APPLICATION.Base.Interfaces;
using HAIRCARE.CORE.Base;
using HAIRCARE.CORE.BaseEnumeration;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HAIRCARE.APPLICATION.Business.AuthenticationFunctions.Queries
{
    public class LoginQuery : IRequest<LoginQueryVm>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginQueryVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IPasswordServices _passwordServices;
        private readonly IJwtService _jwtService;
        
        public LoginQueryHandler(IApplicationDbContext context, IPasswordServices passwordServices, IJwtService jwtService)
        {
            _context = context;
            _passwordServices = passwordServices;
            _jwtService = jwtService;
        }
        public async Task<LoginQueryVm> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users
                 .Include(e => e.UserRole)
                 .Include(e => e.UserGroupRefereces)
                 .ThenInclude(ugr => ugr.UserGroup)
                 .Where(e => e.UserName == request.UserName &&
                             e.DeleteFlag == DeleteFlag.Available.Value)
                 .FirstOrDefaultAsync();


            if (entity == null)
            {
                throw new NotFoundException(string.Format(ApplicationMessage.ERR_MSG_USER_INVALID, ApplicationObjects.USERNAME));
            }

            if (entity.UserState == UserState.Locked.Value)
            {
                throw new ForbiddenAccessException(ApplicationMessage.ERR_MSG_USER_LOCKED);
            }

            if (entity.UserState == UserState.Temporary.Value)
            {
                throw new ForbiddenAccessException(string.Format(ApplicationMessage.ERR_MSG_USER_TEMPORARY, ApplicationObjects.USERNAME));
            }

            if (!_passwordServices.Verify(request.Password, entity.Password))
            {
                throw new NotFoundException(ApplicationMessage.ERR_MSG_USER_INVALID_PASSWORD);
            }

            var user = new LoginQueryVm
            {
                Id = entity.Id,
                UserName = entity.UserName,
                Email = entity.Email,
                RoleName = entity.UserRole.Name,
                UserState = entity.UserState.Value,
                GroupName = entity.UserGroupRefereces.Select(e => e.UserGroup.Name).ToList(),
                DeleteFlag = entity.DeleteFlag.Value,
                LockedDatetime = entity.LockedDateTime.ToString("yyyy-MM-dd"),
                LoginFailureCount = entity.LoginFailureCount,
                PreviousLoggedInDate = entity.PreviousLoggedInDate.ToString("yyyy-MM-dd"),
                AccessToken = _jwtService.CreateAccessToken(new JwtClaimSetting
                {
                    Id = entity.Id,
                    UserName = entity.UserName,
                    Email = entity.Email,
                    Role = entity.UserRole.Code
                })
            };

            return user;
        }
    }
}
