using FlowerSpot.Api.Extensions;
using FlowerSpot.Domain.Sightings;
using FlowerSpot.Domain.Users;
using FlowerSpot.Service.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlowerSpot.Api.Controllers
{
    [ApiController]
    [Authorize(Roles = UserRoles.User)]
    [Route("[controller]")]
    public class SightingsController : ControllerBase
    {
        private readonly ISightingService _sightingService;

        public SightingsController(ISightingService sightingService)
        {
            _sightingService = sightingService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<SightingModel>>> GetAll()
        {
            try
            {
                return Ok(await _sightingService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SightingModel>> Get(int id)
        {
            try
            {
                return Ok(await _sightingService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<SightingModel>> Create([FromBody] CreateSightingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _sightingService.CreateAsync(model, User.GetUserId()));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<SightingModel>> Delete([FromBody] DeleteSightingModel model)
        {
            try
            {
                return Ok(await _sightingService.DeleteAsync(model.SightingId, User.GetUserId()));
            }
            catch (UnauthorizedAccessException ex)
            {
                return StatusCode(StatusCodes.Status403Forbidden, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
