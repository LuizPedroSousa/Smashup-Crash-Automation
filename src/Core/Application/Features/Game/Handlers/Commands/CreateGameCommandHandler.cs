using AutoMapper;
using MediatR;
using Smashup.Application.Contracts.Persistence;
using Smashup.Application.Features.Games.Requests.Commands;
using Smashup.Domain.Modules.Games;

namespace Smashup.Application.Features.Games.Handlers.Commands;

public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, string>
{
  private readonly GameRepository _gameRepository;
  private readonly IMapper _mapper;

  public CreateGameCommandHandler(GameRepository gameRepository, IMapper mapper)
  {
    this._gameRepository = gameRepository;
    this._mapper = mapper;
  }

  public async Task<string> Handle(CreateGameCommand request, CancellationToken cancellationToken)
  {
    var gameDomain = this._mapper.Map<Game>(request.gameDTO);
    var game = await this._gameRepository.Add(gameDomain);

    return game.id;
  }
}
