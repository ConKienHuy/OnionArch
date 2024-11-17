using Core.Entites;

namespace Core.Interfaces;

public interface IUserRepository : IRepository<User>
{
    User GetByUsername(string username);
    User Register(User user);
}