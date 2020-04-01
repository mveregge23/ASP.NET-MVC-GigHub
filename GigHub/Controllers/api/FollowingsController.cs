using System.Linq;
using System.Web.Mvc;
using GigHub.Models;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers.api
{
    public class FollowingsController : Controller
    {

        private ApplicationDbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var artists = _context.Follows
                .Where(f => f.FollowerId == userId)
                .Select(f => f.Following)
                .ToList();

            return View(artists);
        }
    }
}