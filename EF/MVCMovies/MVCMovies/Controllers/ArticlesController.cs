using Microsoft.AspNetCore.Mvc;
using MVCMovies.Entities;
using MVCMovies.Models;
using MVCMovies.Services.Abstractions;

namespace MVCMovies.Controllers
{
    //WebAPI controllers quitan la parte de vistas, se usa puro controlador y hay que especificar rutas por donde accedemos
    //ApiController responde con peticiones http400 si un modelo no es valido. cada error lo regresa como json 
    [ApiController]
    [Route("api/[controller]")] //ruta es /Articles
    public class ArticlesController : ControllerBase //controllerbase no regresa vistas, regresa objetos
    {
        private readonly IActorService _actorService;
        private readonly IMovieArticleService _movieArticleService;
        public ArticlesController(IActorService actorService, IMovieArticleService movieArticleService)
        {
            _actorService = actorService;
            _movieArticleService = movieArticleService;
        }


        [HttpGet]
        public async Task<List<MovieArticles>> Get()
        {
            return await _movieArticleService.GetAllAsync();
        }

        [HttpGet("recentArticles")]
        public async Task<List<MovieArticleRecent>> GetRecent()
        {
            return await _movieArticleService.GetRecent();
        }


        [HttpGet("{id}")]
        public async Task<MovieArticles> Get(int id)
        {
            return await _movieArticleService.GetAsync(id);
        }

        [HttpPost]
        public async Task<MovieArticles> Save(MovieArticleRequest article)
        {
            return await _movieArticleService.AddAsync(article.ToEntity());
        }

        [HttpPut]
        public async Task<MovieArticles> Edit(MovieArticleEdit article)
        {
            return await _movieArticleService.EditAsync(article.ToEntity());
        }

        //Si desean tener control sobre el codigo de respuesta que pueden regresar es enceario encerrar el objeto de 
        //retorno en un ActionResult
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var article = await _movieArticleService.GetAsync(id);

            if (article == null)
            {
                return NotFound();
            }
            return await _movieArticleService.DeleteAsync(id);
        }
    }
}
