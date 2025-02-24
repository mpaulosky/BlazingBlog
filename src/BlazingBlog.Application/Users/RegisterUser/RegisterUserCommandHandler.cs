// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     RegisterUserCommandHandler.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application
// =======================================================

namespace BlazingBlog.Application.Users.RegisterUser;

public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand>
{

	private readonly IAuthenticationService _authenticationService;

	public RegisterUserCommandHandler(IAuthenticationService authenticationService)
	{

		_authenticationService = authenticationService;

	}

	public async Task<Result> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
	{

		var result = await _authenticationService.RegisterUserAsync(
				request.UserName,
				request.Email,
				request.Password
				);

		if (!result.Succeeded) return Result.Fail($"{string.Join(", ", result.Errors)}");

		return Result.Ok();

	}

}