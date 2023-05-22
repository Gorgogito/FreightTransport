using FreightTransport.Application.Contracts.Persistence;
using FreightTransport.Application.Contracts.Persistence.Repositories;
using FreightTransport.Domain.Common;
using FreightTransport.Infrastructure.Persistence;
using FreightTransport.Infrastructure.Repositories.Scoped;
using System.Collections;

namespace FreightTransport.Infrastructure.Repositories
{

  public class UnitOfWork : IUnitOfWork
  {

    private Hashtable _repositories;
    private readonly FreightTransportDbContext _context;

    private ICompanyRepository _companyRepository;
    private IUserRepository _userRepository;

    public ICompanyRepository CompanyRepository => _companyRepository = new CompanyRepository(_context);
    public IUserRepository UserRepository => _userRepository = new UserRepository(_context);

    public UnitOfWork(FreightTransportDbContext context)
    { _context = context; }

    public FreightTransportDbContext FreightTransportDbContext => _context;

    public async Task<int> Complete()
    { return await _context.SaveChangesAsync(); }

    public void Dispose()
    { _context.Dispose(); }

    public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
    {
      if (_repositories == null)
      { _repositories = new Hashtable(); }
      var type = typeof(TEntity);
      if (!_repositories.ContainsKey(type))
      {
        var repositoryType = typeof(RepositoryBase<>);
        var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)));
        _repositories.Add(type, repositoryInstance);
      }
      return (IAsyncRepository<TEntity>)_repositories[type];
    }

  }

}
