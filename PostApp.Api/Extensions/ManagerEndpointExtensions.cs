using PostApp.Api.Endpoints.Drivers;
using PostApp.Api.Endpoints.Missions;

namespace PostApp.Api.Extensions;

public static class ManagerEndpointExtensions
{
    public static void MapManagerEndpoints(this IEndpointRouteBuilder app)
    {
        new CreateMissionEndpoint.EndPoint().MapEndpoint(app);
        new GetAllDriversEndpoint.EndPoint().MapEndpoint(app);
    }
}