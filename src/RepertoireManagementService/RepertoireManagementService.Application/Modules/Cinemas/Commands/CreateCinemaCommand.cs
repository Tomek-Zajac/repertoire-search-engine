using Domain.Entities;
using Mapster;
using Mediator;
using RepertoireManagementService.Application.Common.Persistence.Repositories.Base;
using RepertoireManagementService.Application.Common.Responses;

namespace RepertoireManagementService.Application.Modules.Cinemas.Commands;

public record CreateCinemaCommand(
    string CinemaName,
    string Address,
    string City,
    string State,
    string ZipCode) : IRequest<Response<string>>;


class CreateCinemaCommandyHandler : IRequestHandler<CreateCinemaCommand, Response<string>>
{
    private readonly IRepository<CinemaEntity> _repository;

    public CreateCinemaCommandyHandler(IRepository<CinemaEntity> repository)
    {
        _repository = repository;
    }

    public async ValueTask<Response<string>> Handle(CreateCinemaCommand request, CancellationToken cancellationToken)
    {
        var cinemaToAdd = request.Adapt<CinemaEntity>();

        var result = await _repository.AddAsync(cinemaToAdd, cancellationToken);

        if (result is null)
            return new Response<string> { Success = false };

        return new Response<string>
        {
            Success = true,
            Data = result.Id
        };
    }
}
