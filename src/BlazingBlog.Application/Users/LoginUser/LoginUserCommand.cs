// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     LoginUserCommand.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application
// =======================================================

namespace BlazingBlog.Application.Users.LoginUser;

public class LoginUserCommand : ICommand
{

	public required string UserName { get; set; }

	public required string Password { get; set; }

}
