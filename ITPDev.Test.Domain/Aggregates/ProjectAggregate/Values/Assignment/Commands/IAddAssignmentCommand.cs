using ITPDev.Test.Domain.Aggregates.ProjectAggregate.Values.Commands;

namespace ITPDev.Test.Domain.Aggregates.ProjectAggregate.Values.AssignmentValue.Commands;

public interface IAddAssignmentCommand
{
    public Guid Id { get;  }
    public string Name { get; }
    public DateTime StartAt { get; }
    public DateTime CancelAt { get; }
    public IAddCommentCommand Comment { get; }
}
