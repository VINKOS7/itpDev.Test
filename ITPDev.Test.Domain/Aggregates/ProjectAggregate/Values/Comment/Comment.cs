using Dotseed.Domain;
using ITPDev.Test.Domain.Aggregates.ProjectAggregate.Values.Commands;
using ITPDev.Test.Domain.Aggregates.ProjectAggregate.Values.CommentValue.Enums;

namespace ITPDev.Test.Domain.Aggregates.ProjectAggregate.Values.CommentValue;

public class Comment : ValueObject
{
    public static Comment From(IAddCommentCommand command) => new()
    {
        Id = command.Id,
        Type = command.Type,
        Content = command.Content
    };

    public Guid Id { get; set; }
    public CommentType Type { get; set; }
    public byte[]? Content { get; set; }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Id;
        yield return Type;
        yield return Content;
    }
}
