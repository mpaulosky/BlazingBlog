// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     IAuthenticationService.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application
// =======================================================

namespace BlazingBlog.Application.Authentication;

public interface IAuthenticationService
{

	Task<RegisterUserResponse> RegisterUserAsync(string username, string email, string password);

	Task<bool> LoginUserAsync(string username, string password);

}
