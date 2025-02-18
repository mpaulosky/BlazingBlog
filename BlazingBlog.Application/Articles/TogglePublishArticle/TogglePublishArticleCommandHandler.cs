// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     TogglePublishArticleCommandHandler.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application
// =======================================================

namespace BlazingBlog.Application.Articles.TogglePublishArticle;

public class TogglePublishArticleCommandHandler : ICommandHandler<TogglePublishArticleCommand, ArticleResponse?>
{

	private readonly IArticleService _ArticleService;

	private readonly IUserService _UserService;

	public TogglePublishArticleCommandHandler(IArticleService articleService, IUserService userService)
	{
		_ArticleService = articleService;
		_UserService = userService;
	}

	public async Task<Result<ArticleResponse?>> Handle(TogglePublishArticleCommand request, CancellationToken cancellationToken)
	{

		if (!await _UserService.CurrentUserCanEditArticlesAsync(request.ArticleId))
		{

			return Result.Fail<ArticleResponse?>("You are not authorized to edit this article. How did you get here?");

		}

		var articleToUpdate = await _ArticleService.GetArticleByIdAsync(request.ArticleId);

		if (articleToUpdate is null)
		{

			return Result.Fail<ArticleResponse?>("The article does not exist.");

		}

		articleToUpdate.IsPublished = !articleToUpdate.IsPublished;

		if(articleToUpdate.IsPublished)
			articleToUpdate.PublishedOn=DateTime.Now;

		var article = await _ArticleService.UpdateArticleAsync(articleToUpdate);

		if (article is null)
		{

			return Result.Fail<ArticleResponse?>("The article does not exist.");

		}

		return article.Adapt<ArticleResponse>();

	}

}
