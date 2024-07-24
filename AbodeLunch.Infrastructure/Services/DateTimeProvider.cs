using AbodeLunch.Application.Common.Interfaces.Services;

namespace AbodeLunch.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}