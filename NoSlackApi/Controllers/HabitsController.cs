using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NoSlackApplication.Commands;
using NoSlackApplication.Queries;

namespace NoSlackApi.Controllers;

[ApiController]
[Route("api/habits")]
public class HabitsController : ControllerBase
{
    private readonly IMediator _mediator;
    public HabitsController(IMediator mediator) => _mediator = mediator;
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateHabitRequest request) => Ok(await _mediator.Send(new CreateHabitCommand(request.Name)));

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _mediator.Send(new GetHabitsQuery()));

}
public record CreateHabitRequest(string Name);