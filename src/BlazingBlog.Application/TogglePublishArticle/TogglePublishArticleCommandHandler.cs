// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     TogglePublishArticleCommandHandler.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application
// =======================================================

using BlazingBlog.Application.Articles;

namespace BlazingBlog.Application.TogglePublishArticle;

public class TogglePublishArticleCommandHandler : ICommandHandler<TogglePublishArticleCommand, ArticleResponse>
{

	private readonly IArticleService _articleService;

	private readonly IUserService _userService;

	public TogglePublishArticleCommandHandler(IArticleService articleService, IUserService userService)
	{

		_articleService = articleService;

		_userService = userService;

	}

	public async Task<Result<ArticleResponse>> Handle(
			TogglePublishArticleCommand request,
			CancellationToken cancellationToken)
	{

		if (!await _userService.CurrentUserCanEditArticlesAsync(request.ArticleId))
		{

			return Result.Fail<ArticleResponse>("You are not allowed to edit this article.");

		}

		var articleToUpdate = await _articleService.GetArticleByIdAsync(request.ArticleId);

		if (articleToUpdate is null) return Result.Fail<ArticleResponse>("The article does not exist.");

		articleToUpdate.IsPublished = !articleToUpdate.IsPublished;

		articleToUpdate.ModifiedOn = DateTime.UtcNow;

		if (articleToUpdate.IsPublished) articleToUpdate.PublishedOn = DateTime.UtcNow;

		var article = await _articleService.UpdateArticleAsync(articleToUpdate);

		if (article is null) return Result.Fail<ArticleResponse>("Failed to update the article.");

		return article.Adapt<ArticleResponse>();

	}

}