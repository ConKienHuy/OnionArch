using Core.Interfaces;

namespace Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }
    int Complete();
}