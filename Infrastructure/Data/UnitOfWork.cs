using Application.Interfaces;
using Core.Interfaces;

namespace Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        // Unit of work nhận trách nhiệm cung cấp ApplicatoinDbContext chung
        Users = new UserRepository(context);
    }

    public IUserRepository Users { get; }

    public int Complete()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}