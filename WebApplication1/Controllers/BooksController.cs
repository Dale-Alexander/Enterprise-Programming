using Common.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class BooksController : Controller
    {
        //step 1 : user types in the url to add a book
        // GET: /Books/Create
        //step 2: page is rturned back to the user with empty text fields
        //step 3: User fills in the text fields and submits
        //POST: /Books/Create


        private readonly BooksRepository _booksRepository;
        public BooksController(BooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }
        /* 
         *Constructor injection is good because you dont have to instantiate
         *the repository in each method defined in this controller, you just use 1 instance which
         *is shared across the entire class. 
         *What im talking about is that you dont have to do this everytime in each method:
         *booksRepository booksRepository = new BooksRepository();
         */
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book b)
        {
            try
            {
                _booksRepository.AddBook(b);
                TempData["message"] = "Book added successfully";
            }
            catch(Exception ex)
            {
                //log ex into a file or cloud
                TempData["error"] = "Book was not added. Check your inputs";
            }
            return View();//redirecting the user back to the page where he came from
        }

    }
}
