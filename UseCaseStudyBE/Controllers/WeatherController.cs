using MediatR;
using Microsoft.AspNetCore.Mvc;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.Mapping;
using UseCaseStudyBE.CQRS.Queries.WeatherQueries;

namespace UseCaseStudyBE.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    private readonly IMediator _mediator;

    public WeatherController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public IActionResult GetAllWeatherDatas()
    {
        return Ok(_mediator.Send(new GetAllWeatherQuery()));
    }
    [HttpGet("Today")]
    public IActionResult GetTodayWeatherData()
    {
        return Ok(_mediator.Send(new GetTodayWeatherQuery()));
    }
}