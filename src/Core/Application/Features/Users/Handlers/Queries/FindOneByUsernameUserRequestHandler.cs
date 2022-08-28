using AutoMapper;
using MediatR;
using Smashup.Application.Features.Users.Requests.Queries;
using Smashup.Application.DTOs.Users;
using Smashup.Application.Contracts.Persistence;

namespace Smashup.Application.Features.Users.Handlers.Queries
{


  public class FindOneByUsernameRequestHandler : IRequestHandler<FindOneByUsernameUserRequest, UserDTO>
  {
    private readonly UserRepository _userRepository;
    private readonly IMapper _mapper;

    public FindOneByUsernameRequestHandler(UserRepository userRepository, IMapper mapper)
    {
      this._userRepository = userRepository;
      this._mapper = mapper;
    }


    public async Task<UserDTO> Handle(FindOneByUsernameUserRequest request, CancellationToken cancellationToken)
    {
      var user = await this._userRepository.FindOneByUsername(request.email);

      return _mapper.Map<UserDTO>(user);
    }
  }
}