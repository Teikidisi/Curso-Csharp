using MVCMovies.Models;

namespace MVCMovies.Libs
{
    public class MapProfile: AutoMapper.Profile
    {
        public MapProfile()
        {
            //si dejamos el createmap nada mas, solo se pasaran las propiedades que coincidan entre el nombre y el tipo de dato
            //
            CreateMap<Movie, MovieRecentItem>()
                .ForMember(c => c.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate.ToShortDateString()));
            //para casos en los cuales etnemos que llenar propiedades complejas o personalizadas hay que utilizar ForMember

        }
    }
}
