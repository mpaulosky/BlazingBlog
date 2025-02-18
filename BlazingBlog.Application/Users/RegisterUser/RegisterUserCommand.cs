// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     RegisterUserCommand.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application
// =======================================================

namespace BlazingBlog.Application.Users.RegisterUser;

public class RegisterUserCommand : ICommand
{

	public required string UserName { get; set; }

	public required string Email { get; set; }

	public required string Password { get; set; }

}
