using Microsoft.AspNetCore.Mvc;
using News_Backend.Data_Access._News;
using News_Backend.Models;

namespace News_Backend.Controllers
{
    public class NewsController : Controller
    {
        private INewsDal _newsDal;
        public NewsController(INewsDal newsDal)
        {
            _newsDal = newsDal;
        }

        [HttpGet("[Controller]")]
        public IActionResult GetAll()
        {
            var list = _newsDal.GetList();
            return Ok(list);
        }
        [HttpGet("[Controller]/{id}")]
        public IActionResult Get(int id)
        {
            var news = _newsDal.Get(news => news.Id == id);
            return news == null ? Ok(news): BadRequest();
        }
        [HttpPost("[Controller]/Add")]
        public IActionResult Add([FromBody] News news)
        {
            var addedNews = _newsDal.Add(news);
            return addedNews != null ?  Ok(addedNews): BadRequest();
        }

    }
}
