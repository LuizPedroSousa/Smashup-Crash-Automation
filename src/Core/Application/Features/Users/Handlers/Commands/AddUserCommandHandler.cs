using MediatR;
using AutoMapper;
using Smashup.Application.Contracts.Persistence;
using Smashup.Application.Features.Users.Requests.Commands;
using Smashup.Domain.Modules.Users;

namespace Smashup.Application.Features.Users.Handlers.Commands;

public class AddUserCommandHandler : IRequestHandler<AddUserCommand, string>
{
  private readonly UserRepository _userRepository;
  private readonly IMapper _mapper;

  public AddUserCommandHandler(UserRepository userRepository, IMapper mapper)
  {
    this._userRepository = userRepository;
    this._mapper = mapper;
  }

  public async Task<string> Handle(AddUserCommand request, CancellationToken cancellationToken)
  {
    var userDomain = _mapper.Map<User>(request.userDTO);
    var user = await this._userRepository.Add(userDomain);
    return user.id;
  }
}
