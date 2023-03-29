using Domain.Entities;
using Mapster;
using Mediator;
using RepertoireManagementService.Application.Common.Persistence.Repositories.Base;
using RepertoireManagementService.Application.Common.Responses;
using RepertoireManagementService.Application.Modules.Cinemas.Dtos;

namespace RepertoireManagementService.Application.Modules.Cinemas.Queries;

public record GetCinemasQuery : IRequest<Response<IEnumerable<CinemaDto>>>
{
    public static readonly GetCinemasQuery Instance = new();

    private GetCinemasQuery() { }
}

class GetCinemasQueryHandler : IRequestHandler<GetCinemasQuery, Response<IEnumerable<CinemaDto>>>
{
    private readonly IRepository<CinemaEntity> _repository;

    public GetCinemasQueryHandler(IRepository<CinemaEntity> repository)
    {
        _repository = repository;
    }

    public async ValueTask<Response<IEnumerable<CinemaDto>>> Handle(GetCinemasQuery request, CancellationToken cancellationToken)
    {
        var cinemas = await _repository.GetAllAsync(cancellationToken);

        if (cinemas is null)
            return new Response<IEnumerable<CinemaDto>> { Success = false };

        return new Response<IEnumerable<CinemaDto>>
        {
            Success = true,
            Data = cinemas.Adapt<IEnumerable<CinemaDto>>()
        };
    }
}