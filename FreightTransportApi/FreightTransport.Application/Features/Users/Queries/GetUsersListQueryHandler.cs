using AutoMapper;
using FreightTransport.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace FreightTransport.Application.Features.Users.Queries
{

  public class GetUsersListQueryHandlerByCode : IRequestHandler<GetUsersListQueryByCode, List<UsersResponse>>
  {

    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUsersListQueryHandlerByCode(IUserRepository userRepository, IMapper mapper)
    {
      _userRepository = userRepository;
      _mapper = mapper;
    }

    public async Task<List<UsersResponse>> Handle(GetUsersListQueryByCode request, CancellationToken cancellationToken)
    {
      var userList = await _userRepository.GetUserByCode(request._Id);
      return _mapper.Map<List<UsersResponse>>(userList);
    }

  }

  public class GetCompaniesListQueryHandlerAll : IRequestHandler<GetUsersListQueryAll, List<UsersResponse>>
  {

    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetCompaniesListQueryHandlerAll(IUserRepository userRepository, IMapper mapper)
    {
      _userRepository = userRepository;
      _mapper = mapper;
    }

    public async Task<List<UsersResponse>> Handle(GetUsersListQueryAll request, CancellationToken cancellationToken)
    {
      var genreList = await _userRepository.GetUserAll();
      return _mapper.Map<List<UsersResponse>>(genreList);
    }

  }

}
