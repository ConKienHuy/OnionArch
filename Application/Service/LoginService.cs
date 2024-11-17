using Application.Interfaces;
using Core.Entites;

namespace Application.Service;

public class LoginService : ILoginService
{
    private readonly IUnitOfWork _unitOfWork;

    public LoginService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public bool Login(string username, string password)
    {
        var user = _unitOfWork.Users.GetByUsername(username);

        if (user == null || user.UserPassword != password) return false; // Đăng nhập thất bại

        return true; // Đăng nhập thành công
    }

    public User Register(User user)
    {
        var newUser = _unitOfWork.Users.Register(user);

        return newUser;
    }
}