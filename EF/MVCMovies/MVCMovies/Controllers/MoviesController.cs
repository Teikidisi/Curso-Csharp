using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCMovies.Data;
using MVCMovies.Models;
using MVCMovies.Services;
using MVCMovies.Services.Abstractions;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
namespace MVCMovies.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IActorService _actorService;

        private readonly UserManager<ApplicationUser> _userManager;

        public MoviesController(IMovieService movieService, IActorService actorService, UserManager<ApplicationUser> userManager)
        {
            _movieService = movieService;
            _actorService = actorService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index(MovieFilters filters)
        {
            ViewData["Title"] = "Listado de Películas";

            var vm = new MoviesViewModel
            {
                Movies = await _movieService.GetMoviesAsync(filters),
                Filters = filters,
                Actors = await _actorService.GetActorsAsync(new ActorFilters())
            };
            return View(vm);
        }

        [Authorize(Roles ="Administrator")]
        public async Task<IActionResult> Create()
        {
            var vm = new MoviesActorViewModel
            {
                Actors = await _actorService.GetActorsAsync(new ActorFilters()),
            };
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MoviesActorViewModel movie)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Hay datos invalidos");
                return View();
            }
            movie.Actors = (await _actorService.GetActorsAsync(new ActorFilters()))
                .Where(c => movie.Selected.Contains(c.Id)).ToList();
            //movie.Actors = _context.Actors.Where(c => movie.Selected.Contains(c.Id)).ToList();

            await _movieService.AddAsync(movie);

            //_context.Movies.Add(movie);
            //_context.SaveChanges();
            ViewData["Response"] = $"Pelicula {movie.Title} añadido";
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _movieService.GetAsync(id);
            //var movie = _context.Movies.Find(id);

            if (movie == null)
                return NotFound();

            var movieRequest = new MoviesActorViewModel
            {
                Id = movie.Id,
                Genre = movie.Genre,
                Price = movie.Price,
                Rating = movie.Rating,
                ReleaseDate = movie.ReleaseDate,
                Title = movie.Title,
                Actors = await _actorService.GetActorsAsync(new ActorFilters()),
                Selected = movie.Actors.Select(c => c.Id).ToList(),
            };

            return View(movieRequest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MoviesActorViewModel movie)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Hay datos invalidos");
                return View();
            }

            movie.Actors = (await _actorService.GetActorsAsync(new ActorFilters())).Where(c => movie.Selected.Contains(c.Id)).ToList();
            //var movieDb = _context.Movies.Find(movie.Id);
            await _movieService.EditAsync(movie);

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Administrator")]
        public async  Task<IActionResult> Delete(int id)
        {
            var movie = await _movieService.GetAsync(id);
            if (movie == null)
                return NotFound();
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Movie movie)
        {
            await _movieService.DeleteAsync(movie.Id);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Details(int id)
        {
            var movie = await _movieService.GetWithRatesAsync(id);

            return View(movie);
        }
        [HttpPost]
        public async Task<IActionResult> Rate(RateMovieRequest request)
        {
            var user = await _userManager.GetUserAsync(User);
            var movie = await _movieService.GetAsync(request.Id);

            var done = await _movieService.RateMovieAsync(new UserRate
            {
                Movie = movie,
                User = user,
                Stars = request.Stars,
                Comment = request.Comment
            });

            return RedirectToAction("Details",new { movie.Id});
        }
    }
}
