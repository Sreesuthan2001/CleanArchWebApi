using Microsoft.Extensions.DependencyInjection;
using CleanArch.Application.MappingProfiles;
using Microsoft.Extensions.Hosting;

namespace CleanArch.Application;

public static class ApplicationDependencyInjection
{
	public static IServiceCollection AddApplication(this IServiceCollection services, IHostEnvironment env)
	{
		services.AddServices(env);

		services.RegisterAutoMapper();

		return services;
	}

	private static void AddServices(this IServiceCollection services, IHostEnvironment env)
	{
	}

	private static void RegisterAutoMapper(this IServiceCollection services)
	{
		services.AddAutoMapper(typeof(IMappingProfilesMarker));
	}
}
