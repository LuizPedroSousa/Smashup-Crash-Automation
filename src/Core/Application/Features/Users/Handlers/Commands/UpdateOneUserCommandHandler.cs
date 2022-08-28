using MediatR;
using AutoMapper;
using Smashup.Application.Contracts.Persistence;
using Smashup.Application.Features.Users.Requests.Commands;

namespace Smashup.Application.Features.Users.Handlers.Commands;
public class UpdateOneUserCommandHandler : IRequestHandler<UpdateOneUserCommand, Unit>
{
  private readonly UserRepository _userRepository;
  private readonly IMapper _mapper;

  public UpdateOneUserCommandHandler(UserRepository userRepository, IMapper mapper)
  {
    this._userRepository = userRepository;
    this._mapper = mapper;
  }

  public async Task<Unit> Handle(UpdateOneUserCommand request, CancellationToken cancellationToken)
  {

    var user = await this._userRepository.FindOneById(request.updateUserDto.id);

    var updatedUser = this._mapper.Map(request.updateUserDto, user);

    await this._userRepository.UpdateOne(updatedUser);

    return Unit.Value;
  }
}