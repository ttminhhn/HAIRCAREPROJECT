using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using HAIRCARE.WEBAPI.Models;


namespace HAIRCARE.WEBAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}")]
    public abstract class ApiControllerBase<T> : ControllerBase where T : ApiControllerBase<T>
    {
        private readonly ISender _mediator;
        private readonly ILogger<T> _logger;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        protected BaseResponseModel ResponseData;

        public ApiControllerBase()
        {
            ResponseData = new BaseResponseModel();
        }

        protected ISender Mediator => _mediator ?? HttpContext.RequestServices.GetService<ISender>();
        protected ILogger<T> Logger => _logger ?? HttpContext.RequestServices.GetService<ILogger<T>>();
        protected IConfiguration Configuration => _configuration ?? HttpContext.RequestServices.GetService<IConfiguration>();
        protected IMapper Mapper => _mapper ?? HttpContext.RequestServices.GetService<IMapper>();
    }
}
