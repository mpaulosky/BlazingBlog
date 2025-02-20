// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     UserService.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Infrastructure
// =======================================================

namespace BlazingBlog.Infrastructure.Users;

public class UserService : IUserService
{

	private readonly IArticleService _articleService;

	private readonly UserManager<User> _userManager;

	private readonly RoleManager<IdentityRole> _roleManager;

	private readonly IHttpContextAccessor _httpContextAccessor;

	public UserService(
			IArticleService articleService,
			IHttpContextAccessor httpContextAccessor,
			UserManager<User> userManager,
			RoleManager<IdentityRole> roleManager)
	{

		_articleService = articleService;
		_httpContextAccessor = httpContextAccessor;
		_userManager = userManager;
		_roleManager = roleManager;

	}

	public async Task<string> GetCurrentUserIdAsync()
	{

		var user = await GetCurrentUserAsync();

		if (user is null)
		{

			throw new UserNotAuthorizedException();

		}

		return user.Id;

	}

	public async Task<bool> IsCurrentUserInRoleAsync(string role)
	{

		var user = await GetCurrentUserAsync();

		var result = user is not null && await _userManager.IsInRoleAsync(user, role);

		return result;

	}

	public async Task<bool> CurrentUserCanCreateArticlesAsync()
	{
		var user = await GetCurrentUserAsync();

		if (user is null)
		{

			return false;

		}

		var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

		var isWriter = await _userManager.IsInRoleAsync(user, "Writer");

		var result = isAdmin || isWriter;

		return result;

	}

	public async Task<bool> CurrentUserCanEditArticlesAsync(int articleId)
	{

		var user = await GetCurrentUserAsync();

		if (user is null)
		{

			return false;

		}

		var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

		var isWriter = await _userManager.IsInRoleAsync(user, "Writer");

		var article = await _articleService.GetArticleByIdAsync(articleId);

		if (article is null) return false;

		var result = isAdmin || (isWriter && user.Id == article.UserId);

		return result;

	}

	public async Task<List<string>> GetUserRolesAsync(string userId)
	{

		var user = await _userManager.FindByIdAsync(userId);

		if (user is null) return [];

		var roles = await _userManager.GetRolesAsync(user);

		return roles.ToList();

	}

	public async Task AddRoleToUserAsync(string userId, string roleName)
	{

		var user = await _userManager.FindByIdAsync(userId);

		if (user is null) throw new Exception("User not found");

		if (!await _roleManager.RoleExistsAsync(roleName))
		{

			var roleResult = await _roleManager.CreateAsync(new IdentityRole(roleName));

			if (!roleResult.Succeeded) throw new Exception("Failed to create role");

		}

		var result = await _userManager.AddToRoleAsync(user, roleName);

		if (!result.Succeeded) throw new Exception("Failed to add user to role");

	}

	public async Task RemoveRoleFromUserAsync(string userId, string roleName)
	{

		// Find the user by ID
		var user = await _userManager.FindByIdAsync(userId);

		if (user is null) throw new Exception("User not found");

		// Remove the user from the role
		var result = await _userManager.RemoveFromRoleAsync(user, roleName);

		if (!result.Succeeded) throw new Exception("Failed to remove user from role");

	}

	private async Task<User?> GetCurrentUserAsync()
	{

		var httpContext = _httpContextAccessor.HttpContext;

		if (httpContext?.User is null)
		{

			return null;

		}

		var user = await _userManager.GetUserAsync(httpContext.User);

		return user;

	}

}
