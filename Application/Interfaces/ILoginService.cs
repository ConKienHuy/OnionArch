using Core.Entites;

namespace Application.Interfaces;

public interface ILoginService
{
    bool Login(string userName, string password);

    User Register(User user);
}