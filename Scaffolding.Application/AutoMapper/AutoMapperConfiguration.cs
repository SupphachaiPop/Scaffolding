using AutoMapper;
namespace Scaffolding.Application.AutoMapper
{
    public class AutoMapperServiceConfiguration
    {
        public static IMapper Mapper;

        public static void Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ModelToViewModelMappingProfile());  // Model => View Model => Presentation Layer
                cfg.AddProfile(new ViewModelToModelMappingProfile());  // View Model => Model => Data Layer
            });

            Mapper = config.CreateMapper();
        }
    }
}
