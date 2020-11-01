using Microsoft.Extensions.DependencyInjection;
namespace SimcoeAI.Abstractions.CQRS.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
		public static IServiceCollection AddScopedLifetimeCQRS<T>(this IServiceCollection services)
			=> services.Scan(scan => scan
				.FromAssemblyOf<T>()
				.AddClasses(classes => classes.AssignableTo<IBaseCQRS>())
				.AsImplementedInterfaces()
				.WithScopedLifetime());

		public static IServiceCollection AddSingletonLifetimeCQRS<T>(this IServiceCollection services)
			=> services.Scan(scan => scan
				.FromAssemblyOf<T>()
				.AddClasses(classes => classes.AssignableTo<IBaseCQRS>())
				.AsImplementedInterfaces()
				.WithSingletonLifetime());

		public static IServiceCollection AddTransientLifetimeCQRS<T>(this IServiceCollection services)
			=> services.Scan(scan => scan
				.FromAssemblyOf<T>()
				.AddClasses(classes => classes.AssignableTo<IBaseCQRS>())
				.AsImplementedInterfaces()
				.WithTransientLifetime());
	}
}
