// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     DependencyInjection.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Infrastructure
// =======================================================

using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace BlazingBlog.Infrastructure;

public static class DependencyInjection
{

	public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
	{

		services.AddDbContext<ApplicationDbContext>(options =>
				options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
		);

		services.AddHttpContextAccessor();

		services.AddAuthentication();

		services.AddScoped<IArticleRepository, ArticleRepository>();

		services.AddScoped<IArticleService, ArticleService>();

		services.AddScoped<IUserRepository, UserRepository>();

		services.AddScoped<IUserService, UserService>();

		return services;

	}

	private static void AddAuthentication(this IServiceCollection services)
	{

		services.AddSingleton<IAuthorizationMiddlewareResultHandler, AuthorizationMiddlewareHandler>();

		services.AddScoped<IAuthenticationService, AuthenticationService>();

		services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();

		services.AddCascadingAuthenticationState();

		services.AddAuthorization();

		services.AddAuthentication(options =>
		{

			options.DefaultScheme = IdentityConstants.ApplicationScheme;
			options.DefaultSignInScheme = IdentityConstants.ExternalScheme;

		}).AddIdentityCookies();

		services.AddIdentityCore<User>()
				.AddRoles<IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddSignInManager()
				.AddDefaultTokenProviders();

	}

}