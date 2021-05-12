using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace RC.AutoMapper.Configuration
{
    public static class AutoMapperConfiguration
    {
        private static bool Initialized;
        public static IMapper Mapper { get; private set; }
        public static MapperConfiguration MapperConfiguration { get; private set; }

        public static void Initialize()
        {
            if (!Initialized)
            {
                MapperConfiguration = new MapperConfiguration(cfg =>
                {
                    var profiles = Assembly.GetExecutingAssembly()
                                           .GetExportedTypes()
                                           .Where(x => x.IsClass && typeof(Profile).IsAssignableFrom(x));

                    foreach (var profile in profiles)
                    {
                        cfg.AddProfile((Profile)Activator.CreateInstance(profile));
                    }

                });

                Initialized = true;
            }

            Mapper = MapperConfiguration.CreateMapper();
        }
    }
}
