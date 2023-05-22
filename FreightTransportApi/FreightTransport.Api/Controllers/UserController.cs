using FreightTransport.Application.Features.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FreightTransport.Api.Controllers
{

  [ApiController]
  [Route(Global.Url + "/[controller]")]
  public class UserController : ControllerBase
  {

    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    { _mediator = mediator; }

    [HttpGet("GetCode/{id}", Name = "GetUser")]
    [ProducesResponseType(typeof(IEnumerable<UsersResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<UsersResponse>>> GetUserByCode(long id)
    {
      var query = new GetUsersListQueryByCode(id);
      var user = await _mediator.Send(query);
      return Ok(user);
    }

    [HttpGet("GetAll/", Name = "GetUsers")]
    [ProducesResponseType(typeof(IEnumerable<UsersResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<UsersResponse>>> GetUsersAll()
    {
      var query = new GetUsersListQueryAll();
      var user = await _mediator.Send(query);
      return Ok(user);
    }

  }

}
