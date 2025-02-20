// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     IArticlesOverviewService.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application
// =======================================================

namespace BlazingBlog.Application.Articles;

public interface IArticlesOverviewService
{

	Task<ArticleResponse?> TogglePublishArticleAsync(int articleId);

	Task<List<ArticleResponse>?> GetArticlesByCurrentUserAsync();

}
