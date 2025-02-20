// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     IUser.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Domain
// =======================================================

namespace BlazingBlog.Domain.Users;

public interface IUser
{

	public string Id { get; set; }

	public string? UserName { get; set; }

	public string? Email { get; set; }

	public List<Article.Article> Articles { get; set; }

}
