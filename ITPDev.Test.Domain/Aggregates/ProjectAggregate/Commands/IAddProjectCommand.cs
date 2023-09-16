using ITPDev.Test.Domain.Aggregates.ProjectAggregate.Values.AssignmentValue;
using ITPDev.Test.Domain.Aggregates.ProjectAggregate.Values.AssignmentValue.Commands;

namespace ITPDev.Test.Domain.Aggregates.ProjectAggregate.Commands;

public interface IAddProjectCommand
{
    public string Name { get; }
    public IReadOnlyCollection<IAddAssignmentCommand> Assignments { get; }
}

