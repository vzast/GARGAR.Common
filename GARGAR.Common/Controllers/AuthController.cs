using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace GARGAR.Common.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "4")]
    public class AuthController : ControllerBase
    {
        public AuthController()
        {

        }
    }
}
