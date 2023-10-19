
using AutoMapper;
using ArticulosAPI.Modelos;

namespace ArticulosAPI
{
    public class MappingConfiguration
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Articulo, ArticulosDto>();
                config.CreateMap<ArticulosDto, Articulo>();
            });
            return mappingConfig;
        }
    }


}

