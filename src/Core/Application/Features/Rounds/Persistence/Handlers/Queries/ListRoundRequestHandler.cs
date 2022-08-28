using MediatR;
using AutoMapper;
using Smashup.Application.Features.Rounds.Persistence.Requests.Queries;
using Smashup.Application.Contracts.Persistence;
using Smashup.Application.DTOs.Rounds;

namespace Smashup.Application.Features.Rounds.Persistence.Handlers.Queries;

public class ListRoundRequestHandler : IRequestHandler<ListRoundsRequest, IReadOnlyList<RoundDTO>>
{
  private readonly RoundRepository _roundRepository;
  private readonly IMapper _mapper;

  public ListRoundRequestHandler(RoundRepository roundRepository, IMapper mapper)
  {
    this._roundRepository = roundRepository;
    this._mapper = mapper;
  }

  public async Task<IReadOnlyList<RoundDTO>> Handle(ListRoundsRequest request, CancellationToken cancellationToken)
  {

    var rounds = await this._roundRepository.FindAll();

    return this._mapper.Map<IReadOnlyList<RoundDTO>>(rounds);
  }
}
