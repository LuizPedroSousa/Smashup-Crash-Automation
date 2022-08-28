using MediatR;
using AutoMapper;
using Smashup.Application.Contracts.Persistence;
using Smashup.Application.Features.Users.Requests.Commands;

namespace Smashup.Application.Features.Users.Handlers.Commands;

public class DeleteByIdUserCommandHandler : IRequestHandler<DeleteByIdUserCommand, Unit>
{
  private readonly UserRepository _userRepository;
  private readonly IMapper _mapper;

  public DeleteByIdUserCommandHandler(UserRepository userRepository, IMapper mapper)
  {
    this._userRepository = userRepository;
    this._mapper = mapper;
  }

  public async Task<Unit> Handle(DeleteByIdUserCommand request, CancellationToken cancellationToken)
  {
    await this._userRepository.DeleteById(request.id);

    return Unit.Value;
  }
}