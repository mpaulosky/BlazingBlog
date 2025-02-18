// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     CreateArticleCommand.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application
// =======================================================

namespace BlazingBlog.Application.Articles.CreateArticle;

public class CreateArticleCommand : ICommand<ArticleResponse>
{

	public required string Title { get; set; }

	public string? Content { get; set; }

	public DateTimeOffset? PublishedOn { get; set; } = DateTime.Now;

	public bool IsPublished { get; set; } = false;

}