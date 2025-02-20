// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     GetUserRolesQuery.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application
// =======================================================

namespace BlazingBlog.Application.Users.GetUserRoles;

public class GetUserRolesQuery : IQuery<List<string>>
{

	public required string UserId { get; set; }

}
