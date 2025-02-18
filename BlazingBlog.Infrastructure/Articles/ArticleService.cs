// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     ArticleService.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Infrastructure
// =======================================================

namespace BlazingBlog.Infrastructure.Articles;

public class ArticleService : IArticleService
{

	private readonly IArticleRepository _articleRepository;

	public ArticleService(IArticleRepository articleRepository)
	{

		_articleRepository = articleRepository;

	}

	public async Task<Article?> GetArticleByIdAsync(int id)
	{

		if (id <= 0) return null;

		return await _articleRepository.GetArticleByIdAsync(id);

	}

	public async Task<List<Article>> GetArticlesByUserAsync(string userId)
	{

		if (string.IsNullOrWhiteSpace(userId)) return null;

		return await _articleRepository.GetArticlesByUserAsync(userId);

	}

	public async Task<List<Article>> GetAllAsync()
	{

		return await _articleRepository.GetAllAsync();

	}

	public async Task<Article?> CreateAsync(Article? article)
	{

		if (article is null) return null;

		return await _articleRepository.CreateAsync(article);

	}

	public async Task<bool> DeleteArticleAsync(int id)
	{

		if (id <= 0) return false;

		return await _articleRepository.DeleteArticleAsync(id);

	}

	public async Task<Article?> UpdateArticleAsync(Article? article)
	{

		if (article is null) return null;

		return await _articleRepository.UpdateArticleAsync(article);

	}

}