using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlazorApp1.DataAccess.DTOProfiles;

namespace BlazorApp1.DataAccess
{
    public static class DTOMapper
    {
        static IMapper _mapper;
        private static IConfigurationProvider _config;
        private static IMapper Mapper => _mapper ?? (_mapper = Configuration.CreateMapper());

        public static IConfigurationProvider Configuration
        {
            get
            {
                if (_config == null)
                {
                    var config = new AutoMapper.MapperConfiguration(cfg =>
                    {
                        cfg.AddProfile<MapperProfiles>();
                    });
                    _config = config;
                }
                return _config;
            }
        }

        public static void Map(object source, object dest)
        {
            Mapper.Map(source, dest, source.GetType(), dest.GetType());
        }

        public static T Map<T>(this object source)
        {
            return Mapper.Map<T>(source);
        }

        public static IQueryable<T> ProjectTo<T>(this IQueryable source)
        {
            return source.ProjectTo<T>(DTOMapper.Configuration);
        }
    }
}
