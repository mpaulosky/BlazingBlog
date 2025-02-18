// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     IArticleService.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application
// =======================================================

namespace BlazingBlog.Application.Articles;

public interface IArticleService
{

	Task<Article?> GetArticleByIdAsync(int id);

	Task<List<Article>> GetArticlesByUserAsync(string userId);

	Task<List<Article>> GetAllAsync();

	Task<Article?> CreateAsync(Article article);

	Task<bool> DeleteArticleAsync(int id);

	Task<Article?> UpdateArticleAsync(Article article);

}
