using MediatR;

using ITPDev.Test.Api.Responses;
using ITPDev.Test.Domain.Aggregates.ProjectAggregate;

namespace ITPDev.Test.Api.Requests.Handlers.ProjectHandlers;

public class FetchAssignmentByProjectIdRequestHandler : IRequestHandler<FetchAssignmentsByProjectIdRequest, FetchAssignmentsByProjectIdResponse>
{
    private readonly IProjectRepo _projectRepo;
    private readonly ILogger<AddProjectRequestHandler> _logger;

    public FetchAssignmentByProjectIdRequestHandler(
        IProjectRepo projectRepo,
        ILogger<AddProjectRequestHandler> logger)
    {
        _projectRepo = projectRepo;
        _logger = logger;
    }

    public async Task<FetchAssignmentsByProjectIdResponse> Handle(FetchAssignmentsByProjectIdRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var assignments = await _projectRepo.FetchAssignmentsByProjectIdAsync(request.Id, request.offset, request.size);

            return new FetchAssignmentsByProjectIdResponse(assignments.Select(ass => new AssignmentResponse(ass)).ToList());
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error with attempting fetch assignments by project id, Ex: {ex}");

            throw;
        }
    }
}
