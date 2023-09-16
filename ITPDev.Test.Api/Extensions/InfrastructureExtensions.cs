using ITPDev.Test.Domain.Aggregates.ProjectAggregate;
using ITPDev.Test.Infrastructure.Repo;
using Microsoft.Extensions.DependencyInjection;

namespace ITPDev.Test.Api.Extensions
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services) => services
            .AddScoped<IProjectRepo, ProjectRepo>()
            .AddScoped<IProjectRepo, ProjectRepo>();
    }
}
