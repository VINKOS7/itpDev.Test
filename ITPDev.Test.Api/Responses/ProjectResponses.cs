using ITPDev.Test.Domain.Aggregates.ProjectAggregate;
using ITPDev.Test.Domain.Aggregates.ProjectAggregate.Values.AssignmentValue;
using ITPDev.Test.Domain.Aggregates.ProjectAggregate.Values.CommentValue;
using ITPDev.Test.Domain.Aggregates.ProjectAggregate.Values.CommentValue.Enums;
using Newtonsoft.Json;
namespace ITPDev.Test.Api.Responses;

public class ProjectResponse
{
    public ProjectResponse(Project project)
    {
        Id = project.Id;
        Name = project.Name;
        Assignments = project.Assignments.Select(a => new AssignmentResponse(a)).ToList();
    }

    [JsonProperty("id")]
    public Guid Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("assignments")]
    public ICollection<AssignmentResponse> Assignments { get; set; }
}

public class AssignmentResponse
{
    public AssignmentResponse(Assignment assignment) 
    {
        Id = assignment.Id;
        Name = assignment.Name;
        CreatedAt = assignment.CreatedAt;
        UpdatedAt = assignment.UpdatedAt;
        StartAt = assignment.StartAt;
        CancelAt = assignment.CancelAt;
        Comment = new (assignment.Comment);
    }

    [JsonProperty("id")]
    public Guid Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("createdAt")]
    public DateTime CreatedAt { get; init; }

    [JsonProperty("updatedAt")]
    public DateTime UpdatedAt { get; init; }

    [JsonProperty("startAt")]
    public DateTime StartAt { get; set; }

    [JsonProperty("cancelAt")]
    public DateTime CancelAt { get; set; }

    [JsonProperty("comment")]
    public CommentModel Comment { get; set; }
}

public class CommentModel
{
    public CommentModel(Comment comment)
    {
        Id = comment.Id;
        Type = comment.Type;
        Content = comment.Content;
    }

    [JsonProperty("id")]
    public Guid Id { get; set; }

    [JsonProperty("type")]
    public CommentType Type { get; set; }

    [JsonProperty("content")]
    public byte[]? Content { get; set; }
}

public record FetchProjectsResponse([JsonProperty("projects")] List<ProjectResponse> Projects);

public record FetchAssignmentsByProjectIdResponse([JsonProperty("assignments")] List<AssignmentResponse> Projects);