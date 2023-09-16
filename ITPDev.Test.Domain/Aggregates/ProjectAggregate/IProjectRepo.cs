using Dotseed.Domain;
using ITPDev.Test.Domain.Aggregates.ProjectAggregate.Values.AssignmentValue;

namespace ITPDev.Test.Domain.Aggregates.ProjectAggregate;

public interface IProjectRepo : IRepository<Project>
{
    public Task AddAsync(Project project);
    public Task<Project> FindByIdAsync(Guid Id);
    public Task<List<Project>> FetchAsync(int offset = 0, int size = 20);
    public Task<List<Assignment>> FetchAssignmentsByProjectIdAsync(Guid projectId,int offset, int size);
}
