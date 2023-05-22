using FreightTransport.Application.Contracts.Persistence.Repositories;
using FreightTransport.Domain;
using FreightTransport.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FreightTransport.Infrastructure.Repositories.Scoped
{
  public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
  {
    public CompanyRepository(FreightTransportDbContext context) : base(context) { }

    public async Task<IEnumerable<Company>> GetCompanyAll()
    { return await _context.Companies!.ToListAsync(); }

    public async Task<IEnumerable<Company>> GetCompanyByCode(long id)
    {
      return await _context.Companies!.Where(o => o.Id == id).ToListAsync();
    }

  }
}