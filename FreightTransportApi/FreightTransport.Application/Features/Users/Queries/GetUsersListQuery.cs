using MediatR;

namespace FreightTransport.Application.Features.Users.Queries
{

  public class GetUsersListQueryByCode : IRequest<List<UsersResponse>>
  {

    public long _Id { get; set; } = 0;

    public GetUsersListQueryByCode(long id)
    { _Id = id; }

  }

  public class GetUsersListQueryAll : IRequest<List<UsersResponse>>
  {

    public GetUsersListQueryAll() { }

  }

}
