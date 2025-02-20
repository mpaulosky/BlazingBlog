// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     LoginUserModel.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlogs
// Project Name :  BlazingBlog.WebUI.Server
// =======================================================

using System.ComponentModel.DataAnnotations;

namespace BlazingBlog.WebUI.Server.Features.Users;

public class LoginUserModel
{

	[Required]
	public string UserName { get; set; } = string.Empty;

	[Required]
	public string Password { get; set; } = string.Empty;

}
