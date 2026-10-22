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
        private readonly CategoriesRepository _categoriesRepository;

        public BooksController(BooksRepository booksRepository, CategoriesRepository categoriesRepository)
        {
            _booksRepository = booksRepository;
            _categoriesRepository = categoriesRepository;
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
            //viewBag is dynamic / not strongly typed
            ViewBag.Categories = _categoriesRepository.GetCategories();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book b)
        {
            try
            {
                var count = _booksRepository.GetBooks().Where(x => x.Isbn == b.Isbn).Count();
                if (count == 0){
                    _booksRepository.AddBook(b);
                    ModelState.Clear();
                    TempData["message"] = "Book added successfully";
                }
                else
                {
                    TempData["error"] = "Book already exists";
                }
                //tempdata survives navigation unlike viewdata
            }
            catch(Exception ex)
            {
                //log ex into a file or cloud
                TempData["error"] = "Book was not added. Check your inputs";
            }
            ViewBag.Categories = _categoriesRepository.GetCategories();
            return View();//redirecting the user back to the page where he came from
        }

    }
}
