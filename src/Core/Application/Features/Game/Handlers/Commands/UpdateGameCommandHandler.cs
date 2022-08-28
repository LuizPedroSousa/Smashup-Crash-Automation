using AutoMapper;
using MediatR;
using Smashup.Application.Contracts.Persistence;
using Smashup.Application.Features.Games.Requests.Commands;

namespace Smashup.Application.Features.Games.Handlers.Commands;

public class UpdateGameCommandHandler : IRequestHandler<UpdateGameCommand, Unit>
{
  private readonly GameRepository _gameRepository;
  private readonly IMapper _mapper;

  public UpdateGameCommandHandler(GameRepository gameRepository, IMapper mapper)
  {
    this._gameRepository = gameRepository;
    this._mapper = mapper;
  }

  public async Task<Unit> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
  {

    var game = await this._gameRepository.FindOneById(request.gameDTO.id);

    var gameDomain = this._mapper.Map(request.gameDTO, game);

    await this._gameRepository.UpdateOne(gameDomain);

    return Unit.Value;
  }
}
