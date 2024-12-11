using Microsoft.Extensions.Configuration;

namespace CleanArch.Application.Helpers
{
	public static class ConfigHelper
	{
		private static IConfiguration? _configuration;

		public static void SetConfiguration(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public static string? GetAppSettings(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentException($"name parameter cannot be empty");
			}

			return _configuration?.GetValue<string>(name);
		}

	}
}
