using FreightTransport.Application.Contracts.Persistence;
using FreightTransport.Application.Contracts.Persistence.Repositories;
using FreightTransport.Infrastructure.Persistence;
using FreightTransport.Infrastructure.Repositories;
using FreightTransport.Infrastructure.Repositories.Scoped;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FreightTransport.Infrastructure
{

  public static class InfrastructureServiceRegistration
  {
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {

      services.AddDbContext<FreightTransportDbContext>(options =>
          options.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
      );

      services.AddScoped<IUnitOfWork, UnitOfWork>();
      services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
      services.AddScoped<ICompanyRepository, CompanyRepository>();
      services.AddScoped<IUserRepository, UserRepository>();

      return services;
    }

  }

}
