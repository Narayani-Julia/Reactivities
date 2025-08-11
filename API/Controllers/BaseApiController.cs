using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private IMediator? _mediator;

        //??= if its null, set it to the right of the equals to sign
        protected IMediator Mediator => _mediator ??=
            HttpContext.RequestServices.GetService<IMediator>() ?? throw new InvalidOperationException("IMediatorService is unavailable");
    }
}
