using FreightTransport.ApplicationCore.Infrastructure.Persistence;
using FreightTransport.ApplicationCore.Infrastructure.Repositories;

namespace FreightTransport.ApplicationCore.Business
{

  public class BusinessCompany : CompanyRepository
  {
    public BusinessCompany(IContext context) : base(context)
    { }

  }

  public class BusinessUser : UserRepository
  {
    public BusinessUser(IContext context) : base(context)
    { }

  }

}
