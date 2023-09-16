using MediatR;

using ITPDev.Test.Domain.Aggregates.ProjectAggregate;
using ITPDev.Test.Domain.Aggregates.ProjectAggregate.Values.AssignmentValue;

namespace ITPDev.Test.Api.Requests.Handlers.ProjectHandlers;

public class AddAssignmentsRequestHandler : IRequestHandler<AddAssignmentsRequest>
{
    private readonly IProjectRepo _projectRepo;
    private readonly ILogger<AddProjectRequestHandler> _logger;

    public AddAssignmentsRequestHandler(
        IProjectRepo projectRepo,
        ILogger<AddProjectRequestHandler> logger)
    {
        _projectRepo = projectRepo;
        _logger = logger;
    }

    public async Task Handle(AddAssignmentsRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var project = await _projectRepo.FindByIdAsync(request.ProjectId) ?? throw new BadHttpRequestException("project not found");
            
            if (request.Assignments.Count is 0) throw new BadHttpRequestException("assignments is empty");

            foreach (var assignment in request.Assignments) project.Assignments.Add(Assignment.From(assignment));

            await _projectRepo.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error with attempting added project assignment, Ex: {ex}");

            throw;
        }
    }
}
