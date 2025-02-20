// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     User.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Infrastructure
// =======================================================

namespace BlazingBlog.Infrastructure.Users;

public class User : IdentityUser, IUser
{

	public List<Article> Articles { get; set; } = [];

}
