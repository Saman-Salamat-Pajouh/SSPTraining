using FluentValidation.AspNetCore;
using Hoorbakht.RedisService;
using Hoorbakht.RedisService.Contracts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NLog.Web;
using Sieve.Services;
using SSPTraining.Api.Contracts;
using SSPTraining.Api.Filters;
using SSPTraining.Business.Contract;
using SSPTraining.Business.Decorators;
using SSPTraining.Common;
using SSPTraining.Common.Profiles;
using SSPTraining.Common.Validations;
using SSPTraining.DataAccess;
using SSPTraining.DataAccess.Context;
using SSPTraining.DataAccess.Contracts;
using SSPTraining.Model.Entities;
using System.IO.Compression;
using System.Resources;
using System.Text.Json.Serialization;

namespace SSPTraining.Web;

internal static class DependencyInjectionExtension
{
	internal static IServiceCollection InjectRazorAndApi(this IServiceCollection services) =>
		services.AddRazorPages()
			.Services
			.AddControllers(x => x.Filters.Add<CustomExceptionFilter>())
			.AddJsonOptions(options =>
			{
				options.JsonSerializerOptions.PropertyNamingPolicy = null;
				options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
			})
			.AddApplicationPart(typeof(IBaseController<>).Assembly)
			.Services
			.AddHealthChecks()
			.Services
			.AddSingleton(_ => new ResourceManager(typeof(Messages)));

	internal static IServiceCollection InjectSwagger(this IServiceCollection services) =>
		services.AddSwaggerGen(c =>
			c.SwaggerDoc("v1", new OpenApiInfo { Title = "SSPTraining.Api", Version = "v1" }));

	internal static IServiceCollection InjectUnitOfWork(this IServiceCollection services) =>
		services.AddScoped<IUnitOfWork, UnitOfWork>();

	internal static IServiceCollection InjectContext(this IServiceCollection services,
		IConfiguration configuration, IWebHostEnvironment environment) =>
		environment.IsDevelopment() || environment.IsEnvironment("Testing")
			? services.AddDbContextPool<SspTrainingContext>(options =>
				options.UseInMemoryDatabase("SSP"))
			: services.AddDbContextPool<SspTrainingContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("SSPTrainingContext")));

	internal static IServiceCollection InjectNLog(this IServiceCollection services,
		IWebHostEnvironment environment)
	{
		var factory = NLogBuilder.ConfigureNLog(
				environment.IsProduction()
					? "nlog.config"
					: $"nlog.{environment.EnvironmentName}.config");
		return services.AddSingleton(_ => factory.GetLogger("Info"))
			.AddSingleton(_ => factory.GetLogger("Error"));
	}

	internal static IServiceCollection InjectSieve(this IServiceCollection services) =>
		services.AddScoped<ISieveProcessor, SieveProcessor>();

	internal static IServiceCollection InjectAuthentication(this IServiceCollection services) =>
		services
			.AddAuthorization()
			.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = options.DefaultChallengeScheme =
					CookieAuthenticationDefaults.AuthenticationScheme;
				options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
			})
			.AddCookie(options =>
			{
				options.LoginPath = "/Account/Login";
				options.LogoutPath = "/Account/Logout";
				options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
				options.AccessDeniedPath = "/Account/AccessDenied";
			})
			.Services;

	internal static IServiceCollection InjectBusinesses(this IServiceCollection services) =>
		services.Scan(scan =>
				scan.FromAssembliesOf(typeof(IBaseBusiness<>))
					.AddClasses(classes =>
						classes.AssignableTo(typeof(IBaseBusiness<>)))
					.AsImplementedInterfaces()
					.WithScopedLifetime()
					.AddClasses(classes =>
						classes.Where(predicate =>
							predicate.Name.EndsWith("Business") && !predicate.IsAssignableTo(typeof(IBaseBusiness<>))))
					.AsSelf()
					.WithScopedLifetime())
			.Decorate(typeof(IBaseBusiness<>), typeof(CacheDecorator<>));

	internal static IServiceCollection InjectContentCompression(this IServiceCollection services) =>
		services.Configure<GzipCompressionProviderOptions>
				(options => options.Level = CompressionLevel.Fastest)
			.AddResponseCompression(options => options.Providers.Add<GzipCompressionProvider>());

	internal static IServiceCollection InjectFluentValidation(this IServiceCollection services) =>
		services.AddFluentValidation(fv =>
			fv.RegisterValidatorsFromAssemblyContaining<RoleValidator>());

	internal static IServiceCollection InjectRedisServices(this IServiceCollection services, IConfiguration configuration)
	{
		var connection = new RedisConfiguration(-1,
			"SSPTraining",
			configuration.GetConnectionString("RedisConnectionString"),
			1);

		return services.AddSingleton<IRedisService<Person>>(_ => new RedisService<Person>(connection, "Person"))
			.AddSingleton<IRedisService<User>>(_ => new RedisService<User>(connection, "User"))
			.AddSingleton<IRedisService<Role>>(_ => new RedisService<Role>(connection, "Role"));
	}

	internal static IServiceCollection InjectAutoMapper(this IServiceCollection services) =>
		services.AddAutoMapper(typeof(UserProfile).Assembly);
}