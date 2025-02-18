// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     AuthorizationMiddlewareHandler.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Infrastructure
// =======================================================

namespace BlazingBlog.Infrastructure;

public class AuthorizationMiddlewareHandler : IAuthorizationMiddlewareResultHandler
{

	public Task HandleAsync(
			RequestDelegate next,
			HttpContext context,
			AuthorizationPolicy policy,
			PolicyAuthorizationResult authorizeResult)
	{

		return next(context);

	}

}
