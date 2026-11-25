using Castle.Components.DictionaryAdapter.Xml;
using Common.Interfaces;
using DataAccess.Repositories;

namespace WebApplication1.Factory
{
    public class NotificationFactory
    {
        public INotificationStrategy Create(ReservationsRepository rr, Reservation r)
        {
            int count = rr.GetReservations().Count(
                x => x.DateTaken >= r.DateTaken
                && x.DateReturned == null &&
                r.BookFK == x.BookFK);
            if (count > 0)
            {
                return new DoubleBookingNotificationStrategy();
            }
            else return new AvailableNotificationStrategy();
        }
    }

}
