using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVCMovies.Entities;
using MVCMovies.Models;
using MVCMovies.Services.Abstractions;

namespace MVCMovies.Controllers
{
    [ApiController]
    [Route("api/topMovies")]
    public class MovieTopController : ControllerBase
    {

        private readonly IActorService _actorService;
        private readonly IMovieArticleService _movieArticleService;
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;
        public MovieTopController(IActorService actorService, IMovieArticleService movieArticleService, IMovieService movieService)
        {
            _actorService = actorService;
            _movieArticleService = movieArticleService;
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<List<MovieRecent>> GetRecentAsync()
        {
            return await _movieService.GetRecentAsync();
        }
        [HttpGet("rated")]
        public async Task<List<MoviePopular>> GetTopRated()
        {
            var movie = await _movieService.GetTopRated();
            return movie.Select(x => new MoviePopular
            {
                Title = x.Title,
                Rates = x.Rates,
            }).ToList();

        }

        //[HttpGet("Recent")]
        //public async Task<List<MovieRecentItem>> GetMostRecentMovies()
        //{
        //    var entities = await _movieService.GetRecentAsync();
        //    return entities;
        //}

    }
}
