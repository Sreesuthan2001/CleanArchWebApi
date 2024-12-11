using CleanArch.Application;
using CleanArch.Application.Helpers;
using CleanArch.MySql;
using CleanArch.WebApi.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAll", policy =>
	{
		policy.AllowAnyOrigin()
		.AllowAnyHeader()
		.AllowAnyMethod();
	});
});

builder.Services.AddControllers(
	config => config.Filters.Add(typeof(ValidateModelAttribute))
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigHelper.SetConfiguration(builder.Configuration);

builder.Services.AddDataAccess(builder.Configuration)
	.AddApplication(builder.Environment);

builder.Services.AddMemoryCache();

var app = builder.Build();

var env = app.Environment;
var envVariable = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var environmentName = string.IsNullOrEmpty(envVariable) ? env.EnvironmentName : envVariable;

builder.Configuration
	.SetBasePath(Directory.GetCurrentDirectory())
	.AddJsonFile("appsettings.json", optional: false)
	.AddJsonFile($"appsettings.{environmentName}.json", optional: true)
	.AddEnvironmentVariables();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
