using PostApp.Api.Endpoints.Authentication;

namespace PostApp.Api.Extensions;

public static class AuthEndpointExtensions
{
    public static void MapAuthEndpoints(this IEndpointRouteBuilder app)
    {
        new LoginEndpoint.EndPoint().MapEndpoint(app);
        new RegisterManagerEndpoint.EndPoint().MapEndpoint(app);
        new RegisterDriverEndpoint.EndPoint().MapEndpoint(app);
    }
}