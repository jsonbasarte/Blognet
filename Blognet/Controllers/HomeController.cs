using Blognet.Areas.Identity.Data;
using Blognet.Data;
using Blognet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Blognet.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly BlognetDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, BlognetDbContext dbContext)
        {
            _dbContext = dbContext;
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["UserId"] = _userManager.GetUserId(this.User);
            var results = new List<Post>();
            var posts = await _dbContext.Posts.Include(p => p.Category).Include(p => p.User).ToListAsync();
            foreach (var post in posts)
            {
                if (post.UserId == _userManager.GetUserId(this.User))
                {
                    results.Add(post);
                }
            }
            return View(results);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}