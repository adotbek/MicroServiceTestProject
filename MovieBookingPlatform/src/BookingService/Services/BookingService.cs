using BookingService.Persistense;

namespace BookingService.Services;

public class BookingService(AppDbContext appDbContext) : IBookingService
{
    public Task<long> CreateBookingServiceAsync(long userId, long showtimeId, long seatId)
    {
        
    }
}
