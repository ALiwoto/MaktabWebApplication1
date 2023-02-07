using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaktabWebApplication1.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetDataController : ControllerBase
    {
        [HttpGet]
        public string GetData() => "Ali Abedini";
    }
}
