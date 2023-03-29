using Domain.Entities;
using Mapster;
using Mediator;
using RepertoireManagementService.Application.Common.Persistence.Repositories.Base;
using RepertoireManagementService.Application.Common.Responses;

namespace RepertoireManagementService.Application.Modules.Cinemas.Commands;

public record UpdateCinemaCommand(
    string Id,
    string CinemaName,
    string Address,
    string City,
    string State,
    string ZipCode) : IRequest<Response<bool>>;

class UpdateCinemaCommandHandler : IRequestHandler<UpdateCinemaCommand, Response<bool>>
{
    private readonly IRepository<CinemaEntity> _repository;

    public UpdateCinemaCommandHandler(IRepository<CinemaEntity> repository)
    {
        _repository = repository;
    }

    public async ValueTask<Response<bool>> Handle(UpdateCinemaCommand request, CancellationToken cancellationToken)
    {
        var cinemaToAdd = request.Adapt<CinemaEntity>();

        var updateResult = await _repository.UpdateAsync(cinemaToAdd, cancellationToken);

        return updateResult
            ? new Response<bool> { Success = true }
            : new Response<bool> { Success = false };
    }
}
