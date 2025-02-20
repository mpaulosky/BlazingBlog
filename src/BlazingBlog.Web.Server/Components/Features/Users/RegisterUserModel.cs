// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     RegisterUserModel.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlogs
// Project Name :  BlazingBlog.WebUI.Server
// =======================================================

using System.ComponentModel.DataAnnotations;

namespace BlazingBlog.WebUI.Server.Features.Users;

public class RegisterUserModel
{

	[Required]
	public string UserName { get; set; } = string.Empty;

	[Required]
	[EmailAddress]
	public string Email { get; set; } = string.Empty;

	[Required]
	[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
	[DataType(DataType.Password)]
	[Display(Name = "Password")]
	public string Password { get; set; } = string.Empty;

	[Required]
	[DataType(DataType.Password)]
	[Display(Name = "Confirm password")]
	[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
	public string ConfirmPassword { get; set; } = string.Empty;

}
