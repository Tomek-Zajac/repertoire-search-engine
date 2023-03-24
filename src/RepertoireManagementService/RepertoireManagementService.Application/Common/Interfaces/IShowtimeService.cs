using RepertoireManagementService.Application.Common.Dtos;

namespace RepertoireManagementService.Application.Common.Interfaces;

public interface IShowtimeService
{
    Task<ShowtimesResultDto> GetShowtimes(CancellationToken cancellationToken);
}
