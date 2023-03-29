using Domain.Entities;
using Mapster;
using Mediator;
using RepertoireManagementService.Application.Common.Persistence.Repositories.Base;
using RepertoireManagementService.Application.Common.Responses;

namespace RepertoireManagementService.Application.Modules.Showtimes.Queries;

public record GetShowtimeByIdQuery(string Id) : IRequest<Response<ShowtimeEntity>>;

class GetShowtimeByIdQueryHandler : IRequestHandler<GetShowtimeByIdQuery, Response<ShowtimeEntity>>
{
    private readonly IRepository<ShowtimeEntity> _repository;

    public GetShowtimeByIdQueryHandler(IRepository<ShowtimeEntity> repository)
    {
        _repository = repository;
    }

    public async ValueTask<Response<ShowtimeEntity>> Handle(GetShowtimeByIdQuery request, CancellationToken cancellationToken)
    {
        var cinemas = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (cinemas is null)
            return new Response<ShowtimeEntity> { Success = false };

        return new Response<ShowtimeEntity>
        {
            Success = true,
            Data = cinemas.Adapt<ShowtimeEntity>()
        };
    }
}