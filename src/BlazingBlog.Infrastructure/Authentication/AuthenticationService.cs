// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     AuthenticationService.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Infrastructure
// =======================================================

namespace BlazingBlog.Infrastructure.Authentication;

public class AuthenticationService : IAuthenticationService
{

	private readonly UserManager<User> _userManager;
	private readonly SignInManager<User> _signInManager;

	public AuthenticationService(UserManager<User> userManager, SignInManager<User> signInManager)
	{

		_userManager = userManager;
		_signInManager = signInManager;

	}

	public async Task<RegisterUserResponse> RegisterUserAsync(string username, string email, string password)
	{

		var user = new User
		{
			UserName = username,
			Email = email,
			EmailConfirmed = true
		};

		var result = await _userManager.CreateAsync(user, password);

		if (result.Succeeded) await _userManager.AddToRoleAsync(user, "Reader");

		var response = new RegisterUserResponse
		{

				Succeeded = result.Succeeded,
				Errors = result.Errors.Select(e => e.Description).ToList()

		};

		return response;

	}

	public async Task<bool> LoginUserAsync(string username, string password)
	{

		var result = await _signInManager.PasswordSignInAsync(username, password, false, false);

		return result.Succeeded;

	}

}