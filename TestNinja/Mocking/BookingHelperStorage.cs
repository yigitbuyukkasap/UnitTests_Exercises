﻿using System.Collections.Generic;
using System.Linq;

namespace TestNinja.Mocking
{
    public interface IBookingHelperStorage
    {
        IQueryable<Booking> GetActiveBookings(int? excludedBookingId = null);
    }

    public class BookingHelperStorage : IBookingHelperStorage
    {
        public IQueryable<Booking> GetActiveBookings(int? excludedBookingId = null)
        {
            var unitOfWork = new UnitOfWork();
            var bookings =
                unitOfWork.Query<Booking>()
                    .Where(
                        b => b.Status != "Cancelled");

            if (excludedBookingId.HasValue)
                bookings = bookings.Where(b => b.Id != excludedBookingId.Value);
            
            return bookings;
        }
    }
}
