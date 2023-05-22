using FreightTransport.Application.Features.Companies.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FreightTransport.Api.Controllers
{

  [ApiController]
  [Route(Global.Url + "/[controller]")]
  public class CompanyController : ControllerBase
  {

    private readonly IMediator _mediator;

    public CompanyController(IMediator mediator)
    { _mediator = mediator; }

    [HttpGet("GetCode/{id}", Name = "GetCompany")]
    [ProducesResponseType(typeof(IEnumerable<CompaniesResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<CompaniesResponse>>> GetCompanyByCode(long id)
    {
      var query = new GetCompaniesListQueryByCode(id);
      var company = await _mediator.Send(query);
      return Ok(company);
    }

    [HttpGet("GetAll/", Name = "GetCompanies")]
    [ProducesResponseType(typeof(IEnumerable<CompaniesResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<CompaniesResponse>>> GetCompaniesAll()
    {
      var query = new GetCompaniesListQueryAll();
      var company = await _mediator.Send(query);
      return Ok(company);
    }

  }
}
