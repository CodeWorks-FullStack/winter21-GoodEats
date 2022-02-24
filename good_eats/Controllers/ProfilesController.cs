using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using good_eats.Models;
using good_eats.Services;
using Microsoft.AspNetCore.Mvc;

namespace good_eats.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly ReviewsService _reviewsService;

    public ProfilesController(ReviewsService reviewsService)
    {
      _reviewsService = reviewsService;
    }

    [HttpGet("{id}/reviews")]
    public async Task<ActionResult<List<Review>>> GetReviewsByProfileAsync(string id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        return Ok(_reviewsService.GetReviewsByProfile(id, userInfo?.Id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}