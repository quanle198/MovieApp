using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MovieApp.Areas.Identity.Data;
using MovieApp.Areas.Models;
using MovieApp.Models;
using System.Diagnostics;

namespace MovieApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MovieAppDbContext _context;
        private readonly UserManager<MovieAppUser> _userManager;

        public HomeController(ILogger<HomeController> logger, MovieAppDbContext context, UserManager<MovieAppUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            var movies = _context.Movies.ToList();
            var result = new List<LikeModel>();

            foreach (var movie in movies)
            {
                var likeModel = new LikeModel();
                likeModel.Title = movie.Title;
                likeModel.Path = movie.Path;
                likeModel.MovieId = movie.Id;
                likeModel.Liked = _context.Likes.Where(x => x.UserId == _userManager.GetUserId(User) && x.MovieId == movie.Id).FirstOrDefault() != null ? true : false;
                likeModel.NumOfLikes = _context.Likes.Where(x => x.MovieId == movie.Id).ToList().Count();
                result.Add(likeModel);
            }

            return View(result);
        }

        [HttpPost]
        public IActionResult Like(LikeModel movieModel)
        {
            var like = new Like();
            like.Id = Guid.NewGuid().ToString();
            like.MovieId = movieModel.MovieId;
            like.UserId = _userManager.GetUserId(User);
            _context.Likes.Add(like);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UnLike(LikeModel movieModel)
        {
            var like = _context.Likes.Where(x => x.MovieId == movieModel.MovieId && x.UserId == _userManager.GetUserId(User)).FirstOrDefault();
            if (like != null)
            {
                _context.Likes.Remove(like);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}