using Microsoft.AspNetCore.Mvc;
using API.Errors;

namespace API.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("errors/{code}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorContoller : BaseApiController
    {
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}
