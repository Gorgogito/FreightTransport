using FreightTransport.Application.Contracts.Persistence.Repositories;
using FreightTransport.Domain;
using FreightTransport.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FreightTransport.Infrastructure.Repositories.Scoped
{
  public class UserRepository : RepositoryBase<User>, IUserRepository
  {
    public UserRepository(FreightTransportDbContext context) : base(context) { }

    public async Task<IEnumerable<User>> GetUserAll()
    { return await _context.Users!.ToListAsync(); }

    public async Task<IEnumerable<User>> GetUserByCode(long id)
    {
      return await _context.Users!.Where(o => o.Id == id).ToListAsync();
    }

  }

}
