// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     IUserService.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.WebUI.Server
// =======================================================

namespace BlazingBlog.Application.Users;

public interface IUserService
{

	Task<string> GetCurrentUserIdAsync();

	Task<bool> IsCurrentUserInRoleAsync(string role);

	Task<bool> CurrentUserCanCreateArticlesAsync();

	Task<bool> CurrentUserCanEditArticlesAsync(int articalId);

	Task<List<string>> GetUserRolesAsync(string userId);

	Task AddRoleToUserAsync(string userId, string roleName);

	Task RemoveRoleFromUserAsync(string userId, string roleName);

}