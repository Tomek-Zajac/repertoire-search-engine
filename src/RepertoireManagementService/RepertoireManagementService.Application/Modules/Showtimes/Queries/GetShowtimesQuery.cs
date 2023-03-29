using Domain.Entities;
using Mapster;
using Mediator;
using RepertoireManagementService.Application.Common.Dtos;
using RepertoireManagementService.Application.Common.Persistence.Repositories.Base;
using RepertoireManagementService.Application.Common.Responses;

namespace RepertoireManagementService.Application.Modules.Showtimes.Queries;

public record GetShowtimesQuery : IRequest<Response<IEnumerable<ShowtimeDto>>>
{
    public static readonly GetShowtimesQuery Instance = new();

    private GetShowtimesQuery() { }
}

class GetShowtimesQueryHandler : IRequestHandler<GetShowtimesQuery, Response<IEnumerable<ShowtimeDto>>>
{
    private readonly IRepository<CinemaEntity> _repository;

    public GetShowtimesQueryHandler(IRepository<CinemaEntity> repository)
    {
        _repository = repository;
    }

    public async ValueTask<Response<IEnumerable<ShowtimeDto>>> Handle(GetShowtimesQuery request, CancellationToken cancellationToken)
    {
        var cinemas = await _repository.GetAllAsync(cancellationToken);

        if (cinemas is null)
            return new Response<IEnumerable<ShowtimeDto>> { Success = false };

        return new Response<IEnumerable<ShowtimeDto>>
        {
            Success = true,
            Data = cinemas.Adapt<IEnumerable<ShowtimeDto>>()
        };
    }
}