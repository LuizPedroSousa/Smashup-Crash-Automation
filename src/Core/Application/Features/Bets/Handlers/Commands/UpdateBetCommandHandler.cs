using AutoMapper;
using MediatR;
using Smashup.Application.Features.Bets.Requets.Commands;
using Smashup.Application.Contracts.Persistence;
using Smashup.Domain.Modules.Bets;

namespace Smashup.Application.Features.Bets.Handlers.Commands
{
  public class UpdateBetCommandHandler : IRequestHandler<UpdateBetCommand, Bet>
  {
    private readonly BetRepository _betRepository;
    private readonly IMapper _mapper;

    public UpdateBetCommandHandler(BetRepository betRepository, IMapper mapper)
    {
      this._betRepository = betRepository;
      this._mapper = mapper;
    }

    public async Task<Bet> Handle(UpdateBetCommand request, CancellationToken cancellationToken)
    {

      var bet = await this._betRepository.FindOneById(request.betDTO.id);

      var betUpdated = this._mapper.Map(request.betDTO, bet);
      await this._betRepository.UpdateOne(betUpdated);

      return betUpdated;
    }
  }
}