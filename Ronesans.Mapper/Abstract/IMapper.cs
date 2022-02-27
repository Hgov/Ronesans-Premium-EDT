namespace Ronesans.Mapper.Abstract
{
    public interface IMapper
    {
        TDestination Map<TSource, TDestination>(TSource source);
    }
}
