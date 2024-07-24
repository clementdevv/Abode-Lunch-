using AbodeLunch.Domain.Entities;

namespace AbodeLunch.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        void Add(User user);
    }
}