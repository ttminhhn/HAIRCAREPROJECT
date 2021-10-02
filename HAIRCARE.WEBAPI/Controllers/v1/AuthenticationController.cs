using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using HAIRCARE.APPLICATION.Business.AuthenticationFunctions.Queries.LoginQuery;
using HAIRCARE.APPLICATION.Business.AuthenticationFunctions.Queries.FogotPassWordQuery;
using HAIRCARE.INFRASTURUCTURE.Helpers;

namespace HAIRCARE.WEBAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiController]
    public class AuthenticationController : ApiControllerBase<AuthenticationController>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;

        public AuthenticationController(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _httpContextAccessor = httpContextAccessor;
            _config = config;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> SignIn(LoginQuery request)
        {
            var user = await Mediator.Send(request);
            ResponseData.Add("user", user);
            return Ok(ResponseData);
        }
        [HttpPost]
        [Route("forgotpassword")]
        public async Task<IActionResult> ForgotPassWord(ForgotPassWordQuery request)
        {
            var user = await Mediator.Send(request);
            var verifylink = "https://" + HttpContext.Request.Host + "/api/v1/verifyaccount/" + user.VerifyToken;
            var emailHelper = new EmailHelper(_config);
            var sendEmail = emailHelper.Send(null, user.Email, null, 2, verifylink);
            ResponseData.Add("sendEmail", sendEmail);
            return Ok(ResponseData);
        }
}
}
