// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     ArticlesesOverviewService.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application
// =======================================================

namespace BlazingBlog.Application.Articles;

public class ArticlesesOverviewService : IArticlesOverviewService
{

	private readonly ISender _Sender;

	public ArticlesesOverviewService(ISender sender)
	{

		_Sender = sender;

	}

	public async Task<ArticleResponse?> TogglePublishArticleAsync(int articleId)
	{

		var result = await _Sender.Send(new TogglePublishArticleCommand() { ArticleId = articleId });

		return result;

	}

	public async Task<List<ArticleResponse>> GetArticlesByCurrentUserAsync()
	{

		var result = await _Sender.Send(new GetArticlesByCurrentUserQuery());

		return result;

	}

}
