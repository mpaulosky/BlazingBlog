// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     ArticleRepository.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Infrastructure
// =======================================================

namespace BlazingBlog.Infrastructure.Repositories;

public class ArticleRepository : IArticleRepository
{

	private readonly ApplicationDbContext _context;

	public ArticleRepository(ApplicationDbContext context)
	{

		_context = context;

	}

	public async Task<Article?> GetArticleByIdAsync(int id)
	{

		var article = await _context.Articles.FindAsync(id);

		return article;

	}

	public async Task<List<Article>> GetArticlesByUserAsync(string userId)
	{

		return await _context.Articles
				.Where(a => a.UserId == userId)
				.ToListAsync();

	}

	public async Task<List<Article>> GetAllAsync()
	{

		return await _context.Articles.ToListAsync();

	}

	public async Task<Article?> CreateAsync(Article article)
	{

		_context.Articles.Add(article);

		var result = await _context.SaveChangesAsync();

		return result > 0 ? article : null;

	}

	public async Task<bool> DeleteArticleAsync(int id)
	{

		var articleToDelete = await GetArticleByIdAsync(id);

		if (articleToDelete is null)
		{

			return false;

		}

		_context.Articles.Remove(articleToDelete);

		var result = await _context.SaveChangesAsync();

		return result > 0 ? true : false;

	}

	public async Task<Article?> UpdateArticleAsync(Article article)
	{

		var articleToUpdate = await GetArticleByIdAsync(article.Id);

		if (articleToUpdate is null)
		{

			return null;

		}

		articleToUpdate.Title = article.Title;
		articleToUpdate.Content = article.Content;
		articleToUpdate.PublishedOn = article.PublishedOn;
		articleToUpdate.IsPublished = article.IsPublished;
		articleToUpdate.ModifiedOn = DateTime.Now;

		await _context.SaveChangesAsync();

		return articleToUpdate;

	}

}
