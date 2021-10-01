using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using HAIRCARE.APPLICATION.Business.UserFunctions.Commands;

namespace HAIRCARE.WEBAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiController]
    public class UserController : ApiControllerBase<AuthenticationController>
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;

        public UserController(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _httpContextAccessor = httpContextAccessor;
            _config = config;
        }

        [HttpPost]
        [Route("user/create")]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
    }
}
