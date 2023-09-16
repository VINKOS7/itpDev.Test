using Dotseed.Domain;

using ITPDev.Test.Domain.Aggregates.ProjectAggregate.Commands;
using ITPDev.Test.Domain.Aggregates.ProjectAggregate.Values.AssignmentValue;

namespace ITPDev.Test.Domain.Aggregates.ProjectAggregate;

public class Project : Entity, IAggregateRoot
{
    public static Project From(IAddProjectCommand command) => new()
    {
        Name = command.Name,
        Assignments = command.Assignments.Select(Assignment.From).ToList()
    };

    public string Name { get; set; }
    public ICollection<Assignment> Assignments { get; set; }

}
