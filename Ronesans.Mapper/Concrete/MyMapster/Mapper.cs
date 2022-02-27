using Mapster;
using Ronesans.Mapper.Abstract;

namespace Ronesans.Mapper.Concrete.MyMapster
{
    public class Mapper : IMapper
    {
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return source.Adapt<TDestination>();
        }
    }
}
