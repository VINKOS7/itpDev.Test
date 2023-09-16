using Dotseed.Domain;

using ITPDev.Test.Domain.Aggregates.ProjectAggregate.Values.AssignmentValue.Commands;
using ITPDev.Test.Domain.Aggregates.ProjectAggregate.Values.CommentValue;

namespace ITPDev.Test.Domain.Aggregates.ProjectAggregate.Values.AssignmentValue;

public class Assignment : ValueObject
{
    public static Assignment From(IAddAssignmentCommand command) => new()
    {
        Id = command.Id,
        Name = command.Name,
        StartAt = command.StartAt,
        CancelAt = command.CancelAt,
        Comment = Comment.From(command.Comment)
    };

    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; init; } = DateTime.UtcNow;
    public DateTime StartAt { get; set; }
    public DateTime CancelAt { get; set; }
    public Comment Comment { get; set; }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Id;
        yield return Name;
        yield return CreatedAt;
        yield return UpdatedAt;
        yield return StartAt;
        yield return CancelAt;
    }
}
