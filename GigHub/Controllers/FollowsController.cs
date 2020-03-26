using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers
{
    [System.Web.Http.Authorize]
    public class FollowsController : ApiController
    {

        [System.Web.Http.HttpPost]
        public IHttpActionResult Follow(FollowDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (_context.Follows.Any(f => f.FollowerId == userId && f.FollowingId == dto.ArtistId))
            {
                return BadRequest("You are already following this artist!");
            }

            var follow = new Follow
            {
                FollowerId = userId,
                FollowingId = dto.ArtistId
            };

            _context.Follows.Add(follow);
            _context.SaveChanges();

            return Ok();
        }

        private ApplicationDbContext _context;

        public FollowsController()
        {
            _context = new ApplicationDbContext();
        }

    }

}
