using Common.Interfaces;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApplication1.Controllers
{
    public class ReservationsController: Controller
    {
        private ReservationsRepository _reservationsRepository;
        private IBooksRepository _booksRepository;
        IBookingPolicy _wp;
        IBookingPolicy _sp;
        public ReservationsController(ReservationsRepository reservationsRepository, IBooksRepository booksRepository, [FromKeyedServices("winter")] IBookingPolicy wp, [FromKeyedServices("summer")] IBookingPolicy sp)
        {
            _reservationsRepository = reservationsRepository;
            _booksRepository = booksRepository;
            _wp = wp;
            _sp = sp;
        }

        //todo: Get reservations for logged in user
        [Authorize]//this method will only be accessed by logged in users
        public IActionResult Index()
        {
            var list = _reservationsRepository.GetReservations().Where(x => x.Username == User.Identity.Name);
            return View(list);
        }

        [HttpGet]
        public IActionResult SelfBorrow()
        {
            return View();
        }
        [HttpPost]

        public IActionResult SelfBorrow(Reservation r)
        {

            if(_booksRepository.GetBook(r.BookFK) == null)
            {
                TempData["error"] = "Book doesn't exist";
                return RedirectToAction("Index");
            }
            if(_reservationsRepository.GetReservations().Where(x => x.DateReturned == null && x.BookFK == r.BookFK).Count() == 1)
            {
                TempData["error"] = "Book cannot be borrowed at the moment";
                return RedirectToAction("Index");
            }
            r.DateTaken = DateTime.Now;
            r.Username = User.Identity.Name;
            r.DateReturned = null;
            if(r.DateTaken.Month >= 6 && r.DateTaken.Month <= 9)
            {
                r.DateDue = _sp.CalculateDueDate(r.DateTaken);
            }
            else
            {
                r.DateDue = _wp.CalculateDueDate(r.DateTaken);
            }
            _reservationsRepository.ReserveBook(r);
            TempData["message"] = "Reservation Saved";
            return RedirectToAction("Index");
        }
    }
}
