using MediatR;
using AutoMapper;
using Smashup.Application.Features.Rounds.Persistence.Requests.Commands;
using Smashup.Application.Contracts.Persistence;
using Smashup.Domain.Exceptions.Rounds;
using Smashup.Application.DTOs.Rounds.Persistence.Validators;
using Smashup.Domain.Shared;
using Smashup.Domain.Modules.Rounds;

namespace Smashup.Application.Features.Rounds.Persistence.Handlers.Commands;

public class CreateRoundCommandHandler : IRequestHandler<CreateRoundCommand, Either<InvalidRoundException, string>>
{
  private readonly RoundRepository _roundRepository;
  private readonly GameRepository _gameRepository;
  private readonly IMapper _mapper;

  public CreateRoundCommandHandler(RoundRepository roundRepository, GameRepository gameRepository, IMapper mapper)
  {
    this._roundRepository = roundRepository;
    this._gameRepository = gameRepository;
    this._mapper = mapper;
  }

  public async Task<Either<InvalidRoundException, string>> Handle(CreateRoundCommand request, CancellationToken cancellationToken)
  {
    var validator = new CreateRoundDTOValidator(this._gameRepository);

    var validationResult = await validator.ValidateAsync(request.roundDTO);

    if (!validationResult.IsValid)
    {
      return new InvalidRoundException($"{validationResult.Errors.Select(error => error.ErrorMessage)}");
    }

    var roundDomain = this._mapper.Map<Round>(request.roundDTO);

    var round = await this._roundRepository.Add(roundDomain);

    return round.id;
  }

}
