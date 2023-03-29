using Domain.Entities;
using Mapster;
using Mediator;
using RepertoireManagementService.Application.Common.Persistence.Repositories.Base;
using RepertoireManagementService.Application.Common.Responses;
using RepertoireManagementService.Application.Modules.Cinemas.Dtos;

namespace RepertoireManagementService.Application.Modules.Cinemas.Queries;

public record GetCinemaByIdQuery(string Id) : IRequest<Response<CinemaDto>>;

class GetCinemaByIdQueryHandler : IRequestHandler<GetCinemaByIdQuery, Response<CinemaDto>>
{
    private readonly IRepository<CinemaEntity> _repository;

    public GetCinemaByIdQueryHandler(IRepository<CinemaEntity> repository)
    {
        _repository = repository;
    }

    public async ValueTask<Response<CinemaDto>> Handle(GetCinemaByIdQuery request, CancellationToken cancellationToken)
    {
        var cinemas = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (cinemas is null)
            return new Response<CinemaDto> { Success = false };

        return new Response<CinemaDto>
        {
            Success = true,
            Data = cinemas.Adapt<CinemaDto>()
        };
    }
}