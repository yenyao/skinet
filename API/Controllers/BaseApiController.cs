using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    // Defines it as API controller, serves HTTP responses
    [ApiController]
    // Declares the route
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
    }
}
