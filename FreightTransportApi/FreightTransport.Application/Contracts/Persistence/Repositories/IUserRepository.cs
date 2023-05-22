using FreightTransport.Domain;

namespace FreightTransport.Application.Contracts.Persistence.Repositories
{

  public interface IUserRepository : IAsyncRepository<User>
  {
    Task<IEnumerable<User>> GetUserByCode(long id);
    Task<IEnumerable<User>> GetUserAll();
  }

}
