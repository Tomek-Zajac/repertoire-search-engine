using Domain.Entities;
using Mapster;
using Mediator;
using RepertoireManagementService.Application.Common.Persistence.Repositories.Base;
using RepertoireManagementService.Application.Common.Responses;

namespace RepertoireManagementService.Application.Modules.Showtimes.Commands;

public record CreateShowtimeCommand(
    DateTime DateTime) : IRequest<Response<string>>;


class CreateCinemaCommandyHandler : IRequestHandler<CreateShowtimeCommand, Response<string>>
{
    private readonly IRepository<ShowtimeEntity> _repository;

    public CreateCinemaCommandyHandler(IRepository<ShowtimeEntity> repository)
    {
        _repository = repository;
    }

    public async ValueTask<Response<string>> Handle(CreateShowtimeCommand request, CancellationToken cancellationToken)
    {
        var showtimeToAdd = request.Adapt<ShowtimeEntity>();

        var result = await _repository.AddAsync(showtimeToAdd, cancellationToken);

        if (result is null)
            return new Response<string> { Success = false };

        return new Response<string>
        {
            Success = true,
            Data = result.Id
        };
    }
}
