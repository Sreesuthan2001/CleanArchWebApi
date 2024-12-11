using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CleanArch.MySql.Persistence;

namespace CleanArch.MySql
{
	public static class DataAccessDependencyInjection
	{
		public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDatabase(configuration);

			services.AddRepositories();

			return services;
		}

		private static void AddRepositories(this IServiceCollection services)
		{
		}

		private static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
		{
			string? connectionString = configuration.GetSection("Database").GetSection("ConnectionString").Value;

			services.AddDbContext<DatabaseContext>(options =>
				options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
					opt => opt.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName)));
		}
	}
}
