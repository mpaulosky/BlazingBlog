// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     TogglePublishArticleCommand.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application
// =======================================================

namespace BlazingBlog.Application.Articles.TogglePublishArticle;

public class TogglePublishArticleCommand : ICommand<ArticleResponse?>
{

	public int ArticleId { get; set; }

}
