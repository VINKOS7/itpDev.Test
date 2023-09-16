using MediatR;

using ITPDev.Test.Domain.Aggregates.ProjectAggregate;

namespace ITPDev.Test.Api.Requests.Handlers.ProjectHandlers;

public class AddProjectRequestHandler : IRequestHandler<AddProjectRequest>
{
    private readonly IProjectRepo _projectRepo;
    private readonly ILogger<AddProjectRequestHandler> _logger;

    public AddProjectRequestHandler(
        IProjectRepo projectRepo,
        ILogger<AddProjectRequestHandler> logger)
    {
        _projectRepo = projectRepo;
        _logger = logger;
    }

    public async Task Handle(AddProjectRequest request, CancellationToken cancellationToken)
    {
        try
        {
            if (request is null) throw new BadHttpRequestException("request is bad");
            if (request.Name is null) throw new BadHttpRequestException("name is bad");
            if (request.Assignments is null) throw new BadHttpRequestException("assignments is bad");

            await _projectRepo.AddAsync(Project.From(request));

            await _projectRepo.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error with attempting added project, Ex: {ex}");

            throw;
        }
    }
}
