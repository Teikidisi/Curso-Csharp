using Model.Entities;
using System.Collections.Generic;

namespace BlazorAppNet5.Client.Services.Abstractions
{
    public interface IMovieApi
    {
        List<Movie> GetMovies();
    }
}
