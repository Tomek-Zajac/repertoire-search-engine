using Domain.Entities;
using Mediator;
using RepertoireManagementService.Application.Common.Persistence.Repositories.Base;
using RepertoireManagementService.Application.Common.Responses;

namespace RepertoireManagementService.Application.Modules.Cinemas.Commands;

public record DeleteCinemaCommand(string Id) : IRequest<Response<bool>>;

class DeleteCinemaCommandHandler : IRequestHandler<DeleteCinemaCommand, Response<bool>>
{
    private readonly IRepository<CinemaEntity> _repository;

    public DeleteCinemaCommandHandler(IRepository<CinemaEntity> repository)
    {
        _repository = repository;
    }

    public async ValueTask<Response<bool>> Handle(DeleteCinemaCommand request, CancellationToken cancellationToken)
    {
        var deleteResult = await _repository.DeleteAsync(request.Id, cancellationToken);

        return deleteResult
            ? new Response<bool> { Success = true }
            : new Response<bool> { Success = false };
    }
}