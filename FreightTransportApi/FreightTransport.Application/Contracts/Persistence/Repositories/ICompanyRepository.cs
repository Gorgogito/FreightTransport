using FreightTransport.Domain;

namespace FreightTransport.Application.Contracts.Persistence.Repositories
{

  public interface ICompanyRepository : IAsyncRepository<Company>
  {
    Task<IEnumerable<Company>> GetCompanyByCode(long id);
    Task<IEnumerable<Company>> GetCompanyAll();
  }

}
