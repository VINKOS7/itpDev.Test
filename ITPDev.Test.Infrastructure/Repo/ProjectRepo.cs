using Dotseed.Domain;
using ITPDev.Test.Domain.Aggregates.ProjectAggregate;
using ITPDev.Test.Domain.Aggregates.ProjectAggregate.Values.AssignmentValue;
using Microsoft.EntityFrameworkCore;

namespace ITPDev.Test.Infrastructure.Repo;

public class ProjectRepo : IProjectRepo
{
    private readonly Context _db;

    public ProjectRepo(Context db) => _db = db;

    public IUnitOfWork UnitOfWork => _db;

    public async Task AddAsync(Project project) => await _db.Projects.AddAsync(project);

    public async Task<List<Assignment>> FetchAssignmentsByProjectIdAsync(Guid projectId, int offset, int size) => (await _db.Projects
        .FirstOrDefaultAsync(p => p.Id == projectId))
        .Assignments
        .Skip(offset)
        .Take(size)
        .ToList();

    public async Task<List<Project>> FetchAsync(int offset, int size) => await _db.Projects
        .Skip(offset)
        .Take(size)
        .OrderBy(p => p)
        .ToListAsync();

    public async Task<Project> FindByIdAsync(Guid Id) => await _db.Projects.FirstOrDefaultAsync(p => p.Id == Id);
}