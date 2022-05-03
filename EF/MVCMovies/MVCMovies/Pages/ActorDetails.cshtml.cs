using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MVCMovies.Models;
using MVCMovies.Services.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace MVCMovies.Pages
{
    [Authorize(Roles = "User")]
    public class ActorDetailsModel : PageModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Range(0, 100)]
        [Display(Name = "Oscars Won")]
        public int OscarsWon { get; set; }
        public Sex Sex { get; set; }
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
        public ICollection<UserRateActor> Rates { get; set; } = new List<UserRateActor>();

        private readonly IActorService _actorService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMovieService _movieService;
        public ActorDetailsModel(IActorService actorService, UserManager<ApplicationUser> userManager, IMovieService movieService)
        {
            _actorService = actorService;
            _userManager = userManager;
            _movieService = movieService;
        }

        public async Task<IActionResult> OnGetAsync(int id )
        {
            var user = await _userManager.GetUserAsync(User);
            var actor = await _actorService.GetWithRatesAsync(id);
            if (actor != null)
            {
                Id = actor.Id;
                Name = actor.Name;
                OscarsWon = actor.OscarsWon;
                DateOfBirth = actor.DateOfBirth;
                Sex = actor.Sex;
                Movies = actor.Movies;
                Rates = actor.Rates;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(RateMovieRequest request)
        {
            var user = await _userManager.GetUserAsync(User);
            var movie = await _movieService.GetAsync(request.Id);
            var actor = await _actorService.GetAsync(request.Id);

            var done = await _actorService.RateActorAsync(new UserRateActor
            {
                Actor = actor,
                User = user,
                ActorId = actor.Id,
                Stars = request.Stars,
                Comment = request.Comment
            });

            return RedirectToPage("ActorDetails", new { actor.Id });
        }

        //public async Task<IActionResult> OnPostAsync(int id)
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    //    await 

        //    return RedirectToPage("ActorDetails",new { Id= id});
        //}
    }
}
