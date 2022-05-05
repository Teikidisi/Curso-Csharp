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
    public class ActorController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public ActorController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Add(ActorDTO actor)
        {
            try
            {
                Actor newActor = new Actor();
                newActor.FirstName = actor.FirstName;
                newActor.LastName = actor.LastName;
                newActor.DateOfBirth = actor.DateOfBirth;
                newActor.YearsActive = actor.YearsActive;
                newActor.Image = actor.Image;
                newActor.Description = actor.Description;

                var result = await _appDbContext.Actors.AddAsync(newActor);
                await _appDbContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("all")]
        public async Task<List<ActorDTO>> GetAll()
        {
            var actors = await _appDbContext.Actors.Select(a => new ActorDTO
            {
                Id = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName,
                DateOfBirth = a.DateOfBirth,
                YearsActive = a.YearsActive,
                Image = a.Image,
                Description = a.Description,
            }).ToListAsync();

            return actors;
        }

        [HttpGet("{id}")]
        public async Task<ActorDTO> GetById(int id)
        {
            var actor = await _appDbContext.Actors.Where(a => a.Id.Equals(id))
                .Select(a => new ActorDTO
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    DateOfBirth = a.DateOfBirth,
                    YearsActive = a.YearsActive,
                    Image = a.Image,
                    Description = a.Description,
                }).FirstOrDefaultAsync();
            return actor;
        }

        [HttpPut]
        public async Task<IActionResult> Update(ActorDTO actor)
        {
            try
            {
                var getActor = await _appDbContext.Actors.FirstOrDefaultAsync(a => a.Id.Equals(actor.Id));
                if (getActor != null)
                {
                    getActor.FirstName = actor.FirstName;
                    getActor.LastName = actor.LastName;
                    getActor.DateOfBirth = actor.DateOfBirth;
                    getActor.YearsActive = actor.YearsActive;
                    getActor.Image = actor.Image;
                    getActor.Description = actor.Description;
                }
                else
                {
                    throw new Exception("Actor not found");
                }
                _appDbContext.Update(getActor);
                await _appDbContext.SaveChangesAsync();
                return Ok();


            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
