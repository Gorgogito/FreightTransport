using AutoMapper;
using FreightTransport.Application.Features.Companies.Queries;
using FreightTransport.Application.Features.Users.Queries;
using FreightTransport.Domain;

namespace FreightTransport.Application.Mappings
{

  public class MappingProfile : Profile
  {

    public MappingProfile()
    {
      CreateMap<Company, CompaniesResponse>();
      CreateMap<User, UsersResponse>();      
    }

  }

}
