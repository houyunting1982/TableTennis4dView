using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TableTennis4dView.Application.DTOs.Player;
using TableTennis4dView.Application.Queries.Players;

namespace TableTennis4dView.API.Controllers;

[EnableCors("CorsPolicy")]
[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class PlayersController : ControllerBase
{
    private readonly IMediator _mediator;

    public PlayersController(IMediator mediator) {
        _mediator = mediator;
    }
    [HttpGet("GetAll")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<List<PlayerDto>> Get()
    {
        return (await _mediator.Send(new GetAllPlayersQuery())).ToList();
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(PlayerDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(long id)
    {
        var technique = await _mediator.Send(new GetPlayerByIdQuery(id));
        if (technique == null) {
            return NotFound();
        }

        return Ok(technique);
    }
    
    [HttpGet("UnPurchased/{userId}")]
    [ProducesResponseType(typeof(PlayerDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(string userId) {
        var players = await _mediator.Send(new GetUnPurchasedPlayersByUserQuery(userId));
        return Ok(players);
    }
}
