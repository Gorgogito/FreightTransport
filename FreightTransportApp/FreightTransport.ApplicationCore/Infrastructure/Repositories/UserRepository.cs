using FreightTransport.ApplicationCore.Infrastructure.Persistence;
using FreightTransport.ApplicationCore.Model;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FreightTransport.ApplicationCore.Infrastructure.Repositories
{
  public class UserRepository : IControllerBase<User>
  {
    IContext _context;

    public UserRepository(IContext context) { _context = context; }

    public List<User> GetAll()
    {
      var json = _context.GetAll();
      List<User> models = JsonConvert.DeserializeObject<List<User>>(json);
      return models;
    }

    public List<User> GetByCode(long code)
    {
      var json = _context.GetByCode(code);
      List<User> models = JsonConvert.DeserializeObject<List<User>>(json);
      return models;
    }

    public void AddEntity(User entity)
    {
      throw new System.NotImplementedException();
    }

    public void UpdateEntity(User entity)
    {
      throw new System.NotImplementedException();
    }

    public void DeleteEntity(User entity)
    {
      throw new System.NotImplementedException();
    }

  }
}
