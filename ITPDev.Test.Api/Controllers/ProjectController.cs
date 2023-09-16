using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MediatR;

using ITPDev.Test.Api.Requests;
using ITPDev.Test.Api.Responses;

namespace ITPDev.Test.Api.Controllers;

[Route("projects")]
public class ProjectController : Controller
{
    private readonly IMediator _mediator;

    public ProjectController(IMediator mediator) => _mediator = mediator;


    [AllowAnonymous] [HttpPost("add")] 
    public async Task Add([FromBody] AddProjectRequest request) => await _mediator.Send(request); 


    [AllowAnonymous] [HttpGet("find")] 
    public async Task<ProjectResponse> Find([FromQuery] Guid Id) => await _mediator.Send(new FindProjectRequest(Id));


    [AllowAnonymous] [HttpGet("fetch")] 
    public async Task<FetchProjectsResponse> Fetch([FromQuery] int offset = 0, int size = 20) => await _mediator.Send(new FetchProjectsRequest(offset: offset, size: size));


    [AllowAnonymous] [HttpGet("fetch/assignments")] 
    public async Task<FetchAssignmentsByProjectIdResponse> Fetch([FromQuery] Guid projectId, int offset = 0, int size = 20) => await _mediator.Send(new FetchAssignmentsByProjectIdRequest(Id: projectId, offset: offset, size: size));
}
 