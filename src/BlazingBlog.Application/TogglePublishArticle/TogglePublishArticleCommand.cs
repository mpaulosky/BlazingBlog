// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     TogglePublishArticleCommand.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application
// =======================================================

using BlazingBlog.Application.Articles;

namespace BlazingBlog.Application.TogglePublishArticle;

public class TogglePublishArticleCommand : ICommand<ArticleResponse>
{

	public int ArticleId { get; set; }

}