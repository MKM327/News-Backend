using Microsoft.AspNetCore.Mvc;
using News_Backend.Data_Access._News;
using News_Backend.Models;

namespace News_Backend.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsDal _newsDal;
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
            return news != null ? Ok(news): BadRequest();
        }
        [HttpPost("[Controller]/Add")]
        public IActionResult Add([FromBody] News news)
        {
            var addedNews = _newsDal.Add(news);
            return addedNews != null ?  Ok(addedNews): BadRequest();
        }
        [HttpDelete("[Controller]/Delete")]
        public IActionResult DeleteWithId([FromHeader] int id)
        {
            var news = _newsDal.DeleteWithId(id);
            return news != null ? Ok(news) : BadRequest("id is not valid");
        }

        [HttpPut("[Controller]/Update")]
        public IActionResult Update([FromBody]News news)
        {
           var updatedNews =  _newsDal.Update(news);
           
           return updatedNews != null? Ok(updatedNews): BadRequest("The news doesn't exist in the database!") ;
        }
        [HttpGet("[Controller]/GetWithCategory")]
        public IActionResult GetNewsWithCategory([FromHeader] int id)
        {
            var news = _newsDal.Get(x => x.CategoryId == id);
            return news != null ? Ok(news) : BadRequest("There is no news with this category!");
        }

    }
}
