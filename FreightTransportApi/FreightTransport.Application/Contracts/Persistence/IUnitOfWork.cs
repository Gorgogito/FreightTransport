using FreightTransport.Application.Contracts.Persistence.Repositories;
using FreightTransport.Domain.Common;

namespace FreightTransport.Application.Contracts.Persistence
{

  public interface IUnitOfWork : IDisposable
  {

    ICompanyRepository CompanyRepository { get; }
    IUserRepository UserRepository { get; }

    IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;

    Task<int> Complete();

  }

}
