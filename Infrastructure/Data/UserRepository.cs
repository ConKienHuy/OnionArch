using Core.Entites;
using Core.Interfaces;

namespace Infrastructure.Data;

public class UserRepository : IUserRepository
{
    // context được cung cấp bởi UnitOfWork
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public bool Add(User user)
    {
        var result = _context.Users.Add(user);
        return result.IsKeySet;
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<User> GetAll()
    {
        var userList = _context.Users.ToList();
        return userList;
    }

    public User GetById(int id)
    {
        var user = _context.Users
            .FirstOrDefault(u => u.UserID == id);
        return user;
    }

    public User GetByUsername(string username)
    {
        return _context.Users.FirstOrDefault(u => u.UserName == username);
    }

    public User Register(User user)
    {
        var newUser = _context.Users.Add(user);
        _context.SaveChanges();
        return newUser.Entity;
    }

    public bool Update(User entity)
    {
        throw new NotImplementedException();
    }
}