// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     ArticlesOverviewService.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application
// =======================================================

namespace BlazingBlog.Application.Articles;

public class ArticlesOverviewService : IArticlesOverviewService
{

	private readonly ISender _sender;

	public ArticlesOverviewService(ISender sender)
	{

		_sender = sender;

	}

	public async Task<ArticleResponse?> TogglePublishArticleAsync(int articleId)
	{

		var result = await _sender.Send(new TogglePublishArticleCommand() { ArticleId = articleId });

		return result;

	}

	public async Task<List<ArticleResponse>?> GetArticlesByCurrentUserAsync()
	{

		var result = await _sender.Send(new GetArticlesByCurrentUserQuery());

		return result;

	}

}