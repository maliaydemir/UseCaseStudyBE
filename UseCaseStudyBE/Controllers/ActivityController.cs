using MediatR;
using Microsoft.AspNetCore.Mvc;
using UseCaseStudyBE.CQRS.Commands.ActivityCommands;
using UseCaseStudyBE.Models;
using UseCaseStudyBE.CQRS.Queries.ActivityQueries;

namespace UseCaseStudyBE.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActivityController : Controller
{
    private readonly IMediator _mediator;

    public ActivityController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_mediator.Send(new GetActivityListQuery()));
    }

    [HttpGet("{id}")]
    public IActionResult Get([FromRoute] string id)
    {
        return Ok(_mediator.Send(new GetActivityByIdQuery(id)));
    }

    [HttpPost]
    public IActionResult Post([FromBody] Activity model)
    {
        return Ok(_mediator.Send(new AddActivityCommand(model)));
    }

    [HttpPut]
    public IActionResult Put([FromBody] Activity model)
    {
        return Ok(_mediator.Send(new UpdateActivityCommand(model)));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] string id)
    {
        return Ok(_mediator.Send(new DeleteActivityCommand(id)));
    }
}