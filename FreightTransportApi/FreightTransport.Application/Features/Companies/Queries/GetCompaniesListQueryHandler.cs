using AutoMapper;
using FreightTransport.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace FreightTransport.Application.Features.Companies.Queries
{

  public class GetCompaniesListQueryHandlerByCode : IRequestHandler<GetCompaniesListQueryByCode, List<CompaniesResponse>>
  {

    private readonly ICompanyRepository _companyRepository;
    private readonly IMapper _mapper;

    public GetCompaniesListQueryHandlerByCode(ICompanyRepository companyRepository, IMapper mapper)
    {
      _companyRepository = companyRepository;
      _mapper = mapper;
    }

    public async Task<List<CompaniesResponse>> Handle(GetCompaniesListQueryByCode request, CancellationToken cancellationToken)
    {
      var genreList = await _companyRepository.GetCompanyByCode(request._Id);
      return _mapper.Map<List<CompaniesResponse>>(genreList);
    }

  }

  public class GetCompaniesListQueryHandlerAll : IRequestHandler<GetCompaniesListQueryAll, List<CompaniesResponse>>
  {

    private readonly ICompanyRepository _companyRepository;
    private readonly IMapper _mapper;

    public GetCompaniesListQueryHandlerAll(ICompanyRepository companyRepository, IMapper mapper)
    {
      _companyRepository = companyRepository;
      _mapper = mapper;
    }

    public async Task<List<CompaniesResponse>> Handle(GetCompaniesListQueryAll request, CancellationToken cancellationToken)
    {
      var genreList = await _companyRepository.GetCompanyAll();
      return _mapper.Map<List<CompaniesResponse>>(genreList);
    }

  }

}
