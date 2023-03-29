using Domain.Entities;
using Mediator;
using RepertoireManagementService.Application.Common.Persistence.Repositories.Base;
using RepertoireManagementService.Application.Common.Responses;

namespace RepertoireManagementService.Application.Modules.Showtimes.Commands;

public record DeleteShowtimeCommand(string Id) : IRequest<Response<bool>>;

class DeleteShowtimeCommandHandler : IRequestHandler<DeleteShowtimeCommand, Response<bool>>
{
    private readonly IRepository<ShowtimeEntity> _repository;

    public DeleteShowtimeCommandHandler(IRepository<ShowtimeEntity> repository)
    {
        _repository = repository;
    }

    public async ValueTask<Response<bool>> Handle(DeleteShowtimeCommand request, CancellationToken cancellationToken)
    {
        var deleteResult = await _repository.DeleteAsync(request.Id, cancellationToken);

        return deleteResult
            ? new Response<bool> { Success = true }
            : new Response<bool> { Success = false };
    }
}