using AutoMapper;
using MediatR;
using Smashup.Application.DTOs.Games;
using Smashup.Application.Contracts.Persistence;
using Smashup.Application.Features.Games.Requests.Queries;

namespace Smashup.Application.Features.Games.Handlers.Queries;

public class ListGamesRequestHandler : IRequestHandler<ListGamesRequest, IReadOnlyList<GameDTO>>
{
  private readonly GameRepository _gameRepository;
  private readonly IMapper _mapper;

  public ListGamesRequestHandler(GameRepository gameRepository, IMapper mapper)
  {
    this._gameRepository = gameRepository;
    this._mapper = mapper;
  }

  public async Task<IReadOnlyList<GameDTO>> Handle(ListGamesRequest request, CancellationToken cancellationToken)
  {
    var games = await this._gameRepository.FindAll();

    return this._mapper.Map<IReadOnlyList<GameDTO>>(games);
  }
}
