using MediatR;

namespace FreightTransport.Application.Features.Companies.Queries
{

  public class GetCompaniesListQueryByCode : IRequest<List<CompaniesResponse>>
  {

    public long _Id { get; set; } = 0;

    public GetCompaniesListQueryByCode(long id)
    { _Id = id; }

  }

  public class GetCompaniesListQueryAll : IRequest<List<CompaniesResponse>>
  {

    public GetCompaniesListQueryAll() { }

  }

}
