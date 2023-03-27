using RepertoireSearchEngine.Server.Dtos;

namespace RepertoireSearchEngine.Server.Services.Interfaces;

public interface ICinemaService
{
    Task<IEnumerable<CinemaDto>> GetCinemasAsync(CancellationToken cancellationToken = default);
}
