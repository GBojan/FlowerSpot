using FlowerSpot.Api.Extensions;
using FlowerSpot.Domain.Flowers;
using FlowerSpot.Domain.Users;
using FlowerSpot.Service.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlowerSpot.Api.Controllers
{
    [ApiController]
    [Authorize(Roles = UserRoles.User)]
    [Route("[controller]")]
    public class FlowersController : ControllerBase
    {
        private readonly IFlowerService _flowerService;

        public FlowersController(IFlowerService flowerService)
        {
            _flowerService = flowerService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<FlowerModel>>> GetAll()
        {
            try
            {
                return Ok(await _flowerService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FlowerModel>> Get(int id)
        {
            try
            {
                return Ok(await _flowerService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<FlowerModel>> Create([FromBody] CreateFlowerModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _flowerService.CreateAsync(model, User.GetUserId()));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}