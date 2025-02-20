// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     RemoveRoleFromUserCommand.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application
// =======================================================

namespace BlazingBlog.Application.Users.RemoveRoleFromUser;

public class RemoveRoleFromUserCommand : ICommand
{

		public required string UserId { get; set; }

		public required string RoleName { get; set; }

}
