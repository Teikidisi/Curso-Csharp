using BlazorAppNet5.Client.Services.Abstractions;
using Model.Entities;
using System;
using System.Collections.Generic;

namespace BlazorAppNet5.Client.Services.Implementations
{
    public class MovieApi : Abstractions.IMovieApi
    {

        private readonly string _endpoint = "api/movie";
        
        
        public List<Movie> GetMovies()
        {
            return new List<Movie>
            {
            new Movie { Id = 1, Title = "Spiderman: Homecoming", ReleaseDate = new DateTime(2015,6,28), Poster = "https://th.bing.com/th/id/R.04adc20fa39b4323ad6af1f0b1905338?rik=g0NnoPijuL4YpQ&pid=ImgRaw&r=0"},
            new Movie { Id = 2, Title = "Spiderman: Far From Home", ReleaseDate = new DateTime(2018,6,28), Poster = "https://th.bing.com/th/id/OIP.iV1SS_MvUNdOC1RXvjJUwQHaK-?pid=ImgDet&rs=1"},
            new Movie { Id = 3, Title = "Spiderman: No Way Home", ReleaseDate = new DateTime(2021,6,28), Poster ="https://i2.wp.com/trendienewz.com/wp-content/uploads/2021/11/Spider-Man_-_No_Way_Home_Poster_2.jpg?resize=819%2C1024&ssl=1"},
            };
        }
    }
}
