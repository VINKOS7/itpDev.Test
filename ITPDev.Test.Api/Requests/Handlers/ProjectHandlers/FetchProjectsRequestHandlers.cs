using MediatR;

using ITPDev.Test.Api.Responses;
using ITPDev.Test.Domain.Aggregates.ProjectAggregate;

namespace ITPDev.Test.Api.Requests.Handlers.ProjectHandlers;

public class FetchProjectsRequestHandlers : IRequestHandler<FetchProjectsRequest, FetchProjectsResponse>
{
    private readonly IProjectRepo _projectRepo;
    private readonly ILogger<AddProjectRequestHandler> _logger;

    public FetchProjectsRequestHandlers(
        IProjectRepo projectRepo,
        ILogger<AddProjectRequestHandler> logger)
    {
        _projectRepo = projectRepo;
        _logger = logger;
    }

    public async Task<FetchProjectsResponse> Handle(FetchProjectsRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var projects = await _projectRepo.FetchAsync();

            return new FetchProjectsResponse(Projects: projects.Select(p => new ProjectResponse(p)).ToList());
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error attempting fetch projets, Ex: {ex}");

            throw;
        }
    }
}
