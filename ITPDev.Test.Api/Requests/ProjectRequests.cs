using Newtonsoft.Json;
using MediatR;

using ITPDev.Test.Domain.Aggregates.ProjectAggregate.Commands;
using ITPDev.Test.Domain.Aggregates.ProjectAggregate.Values.AssignmentValue.Commands;
using ITPDev.Test.Domain.Aggregates.ProjectAggregate.Values.Commands;
using ITPDev.Test.Domain.Aggregates.ProjectAggregate.Values.CommentValue.Enums;
using ITPDev.Test.Api.Responses;
using System.Collections.Generic;

namespace ITPDev.Test.Api.Requests;

public record FetchProjectsRequest(
    [JsonProperty("offset")] int offset, 
    [JsonProperty("size")] int size
) 
: IRequest<FetchProjectsResponse>;

public record AddAssignmentsRequest(
    [JsonProperty("projectId")] Guid ProjectId, 
    [JsonProperty("assignments")] IReadOnlyCollection<AssignmentModel> Assignments
) : IRequest;

public record FindProjectRequest([JsonProperty("id")] Guid Id) : IRequest<ProjectResponse>;

public record FetchAssignmentsByProjectIdRequest(
    [JsonProperty("id")] Guid Id, 
    [JsonProperty("offset")] int offset, 
    [JsonProperty("size")] int size
) 
: IRequest<FetchAssignmentsByProjectIdResponse>;

public record AddProjectRequest(
    [JsonProperty("name")] string Name,
    [JsonProperty("assignments")] IReadOnlyCollection<AssignmentModel> Assignments
)
: IAddProjectCommand, IRequest
{
    IReadOnlyCollection<IAddAssignmentCommand> IAddProjectCommand.Assignments => Assignments;
}

//models
public record AssignmentModel(
    [JsonProperty("id")] Guid Id,
    [JsonProperty("name")] string Name,
    [JsonProperty("startAt")] DateTime StartAt,
    [JsonProperty("cancelAt")] DateTime CancelAt,
    [JsonProperty("comment")] AddCommentModel Comment
)
: IAddAssignmentCommand
{
    IAddCommentCommand IAddAssignmentCommand.Comment => Comment;
}

public record AddCommentModel(
    [JsonProperty("id")] Guid Id,
    [JsonProperty("type")] CommentType Type,
    [JsonProperty("content")] byte[] Content
) 
: IAddCommentCommand;