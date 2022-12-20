using Microsoft.AspNetCore.Mvc;

namespace News_Backend.Controllers
{
    public class NewsController : Controller
    {
        [HttpGet("[Controller]")]
        public IActionResult Index()
        {
            return Ok("Test");
        }
        
    }
}
