using HAIRCARE.APPLICATION.Base.Exceptions;
using HAIRCARE.APPLICATION.Base.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HAIRCARE.APPLICATION.Business.AuthenticationFunctions.Queries.FogotPassWordQuery
{
    public class ForgotPassWordQuery : IRequest<FogotPassWordQueryVm>
    {
        public string Email { get; set; }
    }
    public class ForgotPassWordQueryHandler : IRequestHandler<ForgotPassWordQuery, FogotPassWordQueryVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IJwtService _jwtService;

        public ForgotPassWordQueryHandler(IApplicationDbContext context, IJwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        public async Task<FogotPassWordQueryVm> Handle(ForgotPassWordQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users
                .Where(e => e.Email == request.Email)
                .FirstOrDefaultAsync();
            if (entity == null)
            {
                throw new NotFoundException();
            }
            var user = new FogotPassWordQueryVm
            {
                Id = entity.Id,
                Email = entity.Email,
                VerifyToken = _jwtService.CreateVerifyToken(new JwtClaimSetting
                {
                    Id = entity.Id,
                    Email = entity.Email
                })
            };
            return user;
        }
    }
}
