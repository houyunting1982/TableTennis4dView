using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TableTennis4dView.Application.DTOs.Technique;
using TableTennis4dView.Application.Queries.Techniques;
using TableTennis4dView.Core.Entities;

namespace TableTennis4dView.API.Controllers;

[EnableCors("CorsPolicy")]
[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class TechniquesController : ControllerBase
{
    private readonly IMediator _mediator;
    public TechniquesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<List<TechniqueDto>> Get()
    {
        return (await _mediator.Send(new GetAllTechniquesQuery())).ToList();
    }

    // [HttpPost]
    // [ProducesResponseType(StatusCodes.Status201Created)]
    // public async Task<IActionResult> Save()
    // {
    //     
    // }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Technique), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(long id)
    {
        var technique = await _mediator.Send(new GetTechniqueByIdQuery(id));
        if (technique == null) {
            return NotFound();
        }

        return Ok(technique);
    }

    [HttpGet("player/{playerId}")]
    [ProducesResponseType(typeof(Technique), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByPlayerId(long playerId)
    {
        var techniques = await _mediator.Send(new GetTechniquesByPlayerIdQuery(playerId));
        return Ok(techniques);
    }
}
