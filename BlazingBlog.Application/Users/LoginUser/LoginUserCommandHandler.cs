// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     LoginUserCommandHandler.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application
// =======================================================

namespace BlazingBlog.Application.Users.LoginUser;

public class LoginUserCommandHandler : ICommandHandler<LoginUserCommand>
{

	private readonly IAuthenticationService _AuthenticationService;

	public LoginUserCommandHandler(IAuthenticationService authenticationService)
	{

		_AuthenticationService = authenticationService;

	}

	public async Task<Result> Handle(LoginUserCommand request, CancellationToken cancellationToken)
	{

		var success = await _AuthenticationService.LoginUserAsync(
				request.UserName,
				request.Password
				);

		if (success) return Result.Ok();

		return Result.Fail("Invalid username or password");

	}

}
