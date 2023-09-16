using ITPDev.Test.Domain.Aggregates.ProjectAggregate.Values.CommentValue.Enums;

namespace ITPDev.Test.Domain.Aggregates.ProjectAggregate.Values.Commands;

public interface IAddCommentCommand
{
    public Guid Id { get; }
    public CommentType Type { get; }
    public byte[] Content { get; }
}
