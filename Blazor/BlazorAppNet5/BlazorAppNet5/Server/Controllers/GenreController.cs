using BlazorAppNet5.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using System;
using System.Threading.Tasks;

namespace BlazorAppNet5.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly AppDbContext context;

        public GenreController(AppDbContext context)
        {
            this.context = context;
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(GenreDTO model)
        {
            try
            {
                var genre = new Genre(model.Name);

                await context.Genres.AddAsync(genre);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
