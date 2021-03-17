using BlazorDeck.Server.Managers;
using Microsoft.AspNetCore.Mvc;

namespace BlazorDeck.Server.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly BookManager tileConfigManager;

        public BooksController(BookManager tileConfigManager)
        {
            this.tileConfigManager = tileConfigManager;
        }

        [Route("{bookName}")]
        public ActionResult GetBook(string bookName)
        {
            var book = tileConfigManager.GetBook(bookName);
            if(book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
    }
}
