using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //If youre doing this for each controller, you could also say something like:
    //[Route("api/activity")]
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
