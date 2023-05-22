using FreightTransport.ApplicationCore.Infrastructure.Persistence;
using FreightTransport.ApplicationCore.Model;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FreightTransport.ApplicationCore.Infrastructure.Repositories
{
  public class CompanyRepository : IControllerBase<Company>
  {
    IContext _context;

    public CompanyRepository(IContext context) { _context = context; }

    public List<Company> GetAll()
    {
      var json = _context.GetAll();
      List<Company> models = JsonConvert.DeserializeObject<List<Company>>(json);
      return models;
    }

    public List<Company> GetByCode(long code)
    {
      var json = _context.GetByCode(code);
      List<Company> models = JsonConvert.DeserializeObject<List<Company>>(json);
      return models;
    }

    public void AddEntity(Company entity)
    {
      throw new System.NotImplementedException();
    }

    public void UpdateEntity(Company entity)
    {
      throw new System.NotImplementedException();
    }

    public void DeleteEntity(Company entity)
    {
      throw new System.NotImplementedException();
    }

  }
}

