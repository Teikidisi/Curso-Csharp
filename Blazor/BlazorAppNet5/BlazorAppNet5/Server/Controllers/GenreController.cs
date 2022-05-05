using BlazorAppNet5.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet("all")]
        public async Task<List<GenreDTO>> GetAll()
        {
            return await context.Genres.Select(g => new GenreDTO
            {
                Name = g.Name,
                Id = g.Id,
            }).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<GenreDTO> GetById(int id)
        {
            return await context.Genres.Select(g => new GenreDTO
            {
                Name = g.Name,
                Id = g.Id,
            }).FirstOrDefaultAsync(g => g.Id.Equals(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update(GenreDTO model)
        {
            try
            {
                var genre = await context.Genres.FirstOrDefaultAsync(g => g.Id.Equals(model.Id));
                if (genre != null)
                {
                    genre.Name = model.Name;
                }
                else
                {
                    throw new Exception("Element not found");
                }

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
