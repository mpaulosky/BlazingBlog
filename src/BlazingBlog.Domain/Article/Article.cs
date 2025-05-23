// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     Article.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Domain
// =======================================================

namespace BlazingBlog.Domain.Article;

public class Article : Entity
{

	public required string Title { get; set; }

	public string? Content { get; set; }

	public DateTimeOffset? PublishedOn { get; set; } = DateTime.Now;

	public bool IsPublished { get; set; }

	public string UserId { get; set; } = string.Empty;

}