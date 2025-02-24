// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     UpdateArticleCommand.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application
// =======================================================

namespace BlazingBlog.Application.Articles.UpdateArticle;

public class UpdateArticleCommand : ICommand<ArticleResponse?>
{

	public int Id { get; set; }

	public required string Title { get; set; }

	public string? Content { get; set; }

	public bool IsPublished { get; set; }

	public DateTimeOffset? PublishedOn { get; set; }

	public DateTimeOffset? ModifiedOn { get; set; }

}