using AutoMapper;
using DYS.FinanceTracker.Shared.Providers;
using DYS.FinanceTracker.Shared.Settings;
using System.Reflection;

namespace DYS.FinanceTracker.Shared.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddScopedForBaseClass<TBase, TInterface>(this IServiceCollection services, Assembly assembly)
        {
            var baseClassType = typeof(TBase);
            var baseInterfaceType = typeof(TInterface);

            // Find all classes that inherit from the base class and implement an interface derived from the base interface
            var types = assembly.GetTypes()
                .Where(type => type.IsClass
                               && !type.IsAbstract
                               && baseClassType.IsAssignableFrom(type)
                               && type.GetInterfaces().Any(i => i != baseInterfaceType && baseInterfaceType.IsAssignableFrom(i)));

            // Register each type with the DI container
            foreach (var type in types)
            {
                var implementedInterface = type.GetInterfaces()
                    .FirstOrDefault(i => i != baseInterfaceType && baseInterfaceType.IsAssignableFrom(i));

                if (implementedInterface != null)
                {
                    services.AddScoped(implementedInterface, type);
                }
            }
        }

        public static void AddScopedForBaseClass<TBase>(this IServiceCollection services, Assembly assembly)
        {
            var baseType = typeof(TBase);

            // Find all classes that inherit from the base class
            var types = assembly.GetTypes()
                .Where(type => type.IsClass && !type.IsAbstract && baseType.IsAssignableFrom(type));

            // Register each derived type with scoped lifetime
            foreach (var type in types) services.AddScoped(type);
        }

        public static IServiceCollection AddOtherServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(AutoMappings).Assembly);
            serviceCollection.AddSingleton<IMapper, Mapper>();
            serviceCollection.AddScoped<IRequestProvider, RequestProvider>();
            return serviceCollection;
        }
    }
}
