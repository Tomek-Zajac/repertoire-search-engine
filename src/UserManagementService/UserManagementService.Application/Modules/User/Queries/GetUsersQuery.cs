using MediatR;

namespace UserManagementService.Application.Modules.User.Queries;

public record class GetUsersQuery : IRequest<GetUsersResponse>;

public record GetUsersResponse;
