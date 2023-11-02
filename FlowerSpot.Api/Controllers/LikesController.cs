using FlowerSpot.Api.Extensions;
using FlowerSpot.Domain.Likes;
using FlowerSpot.Domain.Users;
using FlowerSpot.Service.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlowerSpot.Api.Controllers
{
    [ApiController]
    [Authorize(Roles = UserRoles.User)]
    [Route("[controller]")]
    public class LikesController : ControllerBase
    {
        private readonly ILikesService _likesService;

        public LikesController(ILikesService likesService)
        {
            _likesService = likesService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LikeModel>> Get(int id)
        {
            try
            {
                return Ok(await _likesService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("user_likes")]
        public async Task<ActionResult<IEnumerable<LikeModel>>> GetByUser()
        {
            try
            {
                return Ok(await _likesService.GetForUserAsync(User.GetUserId()));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<LikeModel>> Create([FromBody] CreateLikeModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _likesService.CreateAsync(model.SightingId, User.GetUserId()));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<DeleteLikeResponseModel>> Delete([FromBody] DeleteLikeModel model)
        {
            try
            {
                return Ok(await _likesService.DeleteAsync(model.LikeId, User.GetUserId()));
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