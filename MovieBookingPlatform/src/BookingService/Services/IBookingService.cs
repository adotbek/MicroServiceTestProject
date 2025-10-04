namespace BookingService.Services;

public interface IBookingService
{
    Task<long> CreateBookingServiceAsync(long userId, long showtimeId, long seatId);

}
