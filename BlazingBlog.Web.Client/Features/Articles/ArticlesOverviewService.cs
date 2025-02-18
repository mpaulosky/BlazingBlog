// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     ArticlesOverviewService.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.WebUI.Client
// =======================================================

using System.Net.Http.Json;

using BlazingBlog.Application.Articles;

namespace BlazingBlog.WebUI.Client.Features.Articles;

public class ArticlesOverviewService : IArticlesOverviewService
{

	private readonly HttpClient _Http;

	public ArticlesOverviewService(HttpClient http)
	{

		_Http = http;

	}

	public async Task<ArticleResponse?> TogglePublishArticleAsync(int articleId)
	{

		var result = await _Http.PatchAsync($"api/articles/{articleId}", null);

		if(result is not null && result.Content is not null)
		{

			return await result.Content.ReadFromJsonAsync<ArticleResponse>();

		}

		return null;

	}

	public async Task<List<ArticleResponse>?> GetArticlesByCurrentUserAsync()
	{

		return await _Http.GetFromJsonAsync<List<ArticleResponse>>("api/articles");

	}

}
