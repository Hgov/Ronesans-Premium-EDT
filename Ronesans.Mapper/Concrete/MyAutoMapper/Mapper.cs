using AutoMapper;
using Ronesans.Mapper.Concrete.Helpers;
using System.Collections.Generic;

namespace Ronesans.Mapper.Concrete.MyAutoMapper
{
    public class Mapper : Abstract.IMapper
    {
        public Mapper()
        {
            var profiles = new List<Profile>
            {
                new AutoMapperProfile()
            };
            AutoMapper.Mapper.Initialize(config =>
            {
                foreach (var item in profiles)
                {
                    config.AddProfile(item);
                }
            });
        }
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return AutoMapper.Mapper.Map<TDestination>(source);
        }

    }
}
