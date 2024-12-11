using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CleanArch.MySql.Persistence
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions options) : base(options) { }


		#region DbSet

		#endregion

		protected override void OnModelCreating(ModelBuilder builder)
		{
			//Apply configurations to Database Tables & Columns from DAL -> Persistence -> Configurations
			builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			base.OnModelCreating(builder);
		}
	}
}
