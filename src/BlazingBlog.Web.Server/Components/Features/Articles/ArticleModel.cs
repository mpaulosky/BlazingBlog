// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     ArticleModel.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlogs
// Project Name :  BlazingBlog.WebUI.Server
// =======================================================

namespace BlazingBlog.WebUI.Server.Features.Articles;

public class ArticleModel
{

	public int Id { get; set; }

	public string Title { get; set; } = string.Empty;

	public string? Content { get; set; }

	public DateTimeOffset? PublishedOn { get; set; } = DateTime.Now;

	public bool IsPublished { get; set; } = false;

	public string? UserName { get; set; } = null;

	public string? UserId { get; set; } = null;

	public bool CanEdit { get; set; } = false;

}