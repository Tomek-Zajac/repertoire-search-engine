using Domain.Entities;
using Mapster;
using Mediator;
using RepertoireManagementService.Application.Common.Persistence.Repositories.Base;
using RepertoireManagementService.Application.Common.Responses;

namespace RepertoireManagementService.Application.Modules.Showtimes.Commands;

public record UpdateShowtimeCommand(
    DateTime DateTime) : IRequest<Response<bool>>;

class UpdateShowtimeCommandHandler : IRequestHandler<UpdateShowtimeCommand, Response<bool>>
{
    private readonly IRepository<ShowtimeEntity> _repository;

    public UpdateShowtimeCommandHandler(IRepository<ShowtimeEntity> repository)
    {
        _repository = repository;
    }

    public async ValueTask<Response<bool>> Handle(UpdateShowtimeCommand request, CancellationToken cancellationToken)
    {
        var showtimeToUpdate = request.Adapt<ShowtimeEntity>();

        var updateResult = await _repository.UpdateAsync(showtimeToUpdate, cancellationToken);

        return updateResult
            ? new Response<bool> { Success = true }
            : new Response<bool> { Success = false };
    }
}
