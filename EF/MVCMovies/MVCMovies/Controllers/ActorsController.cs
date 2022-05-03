using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MVCMovies.Data;
using MVCMovies.Models;
using MVCMovies.Services;
using MVCMovies.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Memory;

namespace MVCMovies.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorService _actorService;
        private readonly IMovieService _movieService;
        private readonly IMemoryCache _memoryCache;
        public ActorsController(IActorService actorService, IMovieService movieService, IMemoryCache memoryCache)
        {
            _actorService = actorService;
            _memoryCache = memoryCache;
            _movieService = movieService;
        }
        public async Task<IActionResult> Index(ActorFilters filters)
        {
            //var search2 = Request.Query["search"];
            //var filter = new ActorFilters
            //{
            //    Search = search,
            //    From = from,
            //    To = to,
            //    Sex = sex,
            //};

            List<Actor> actors = new();
            //existe informacion de actores en cache? if yes: leer cache, if no: leer de DB y guardar en cache
            if(!_memoryCache.TryGetValue("actors",out List<Actor> cacheValue))
            {
                cacheValue = await _actorService.GetActorsAsync(filters);

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(5))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));

                _memoryCache.Set("actors", cacheValue, cacheEntryOptions);
            }
            //leer de cache aqui, o asignar nuevo cache arriba si no habia
            actors = cacheValue;

            var vm = new ActorsViewModel
            {
                Actors = actors,
                Filters = filters,
                Movies = await _movieService.GetMoviesAsync(new MovieFilters()),
            };

            return View(vm);
        }
        //GET
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Actor actor)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("","Hay datos invalidos");
                return View();
            }

            actor = await _actorService.AddAsync(actor);
            ViewData["Response"] = $"Actor {actor.Name} añadido";
            _memoryCache.Remove("actors");
            return View(actor);
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id)
        {
            var actor = await _actorService.GetAsync(id);
            var movies = await _actorService.GetMoviesWithActor(id);

            var actorMovies = new ActorToMovies
            {
                Id = actor.Id,
                Name = actor.Name,
                DateOfBirth = actor.DateOfBirth,
                OscarsWon = actor.OscarsWon,
                Sex = actor.Sex,
                Movies = movies,
            };

            if (actor == null)
                return NotFound();

            return View(actorMovies);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Actor actor)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Hay datos invalidos");
                return View();
            }
            actor = await _actorService.EditAsync(actor);
            
            if (actor == null)
                return NotFound();
            _memoryCache.Remove("actors");
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Administrator")]
        public async  Task<IActionResult> Delete(int id)
        {
            var actor = await _actorService.GetAsync(id);
            if (actor == null)
                return NotFound();

            return View(actor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Actor actor)
        {

            await _actorService.DeleteAsync(actor.Id);
            _memoryCache.Remove("actors");
            return RedirectToAction(nameof(Index));

        }

    }
}
