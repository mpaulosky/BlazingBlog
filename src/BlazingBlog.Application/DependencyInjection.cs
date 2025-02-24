// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     DependencyInjection.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application
// =======================================================

namespace BlazingBlog.Application;

public static class DependencyInjection
{

	public static IServiceCollection AddApplication(this IServiceCollection services)
	{

		services.AddMediatR(configuration =>
		{

			configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);

		});

		services.AddScoped<IArticlesOverviewService, ArticlesOverviewService>();

		return services;

	}

}