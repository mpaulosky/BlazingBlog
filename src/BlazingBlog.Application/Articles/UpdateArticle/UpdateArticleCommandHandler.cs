// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     UpdateArticleCommandHandler.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application
// =======================================================

namespace BlazingBlog.Application.Articles.UpdateArticle;

public class UpdateArticleCommandHandler : ICommandHandler<UpdateArticleCommand, ArticleResponse?>
{

	private readonly IArticleService _articleService;

	private readonly IUserService _userService;

	public UpdateArticleCommandHandler(IArticleService articleService, IUserService userService)
	{

		_articleService = articleService;
		_userService = userService;

	}

	public async Task<Result<ArticleResponse?>> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
	{

		var updatedArticle = request.Adapt<Article>();

		updatedArticle.ModifiedOn = DateTimeOffset.UtcNow;

		if (!await _userService.CurrentUserCanEditArticlesAsync(updatedArticle.Id))
		{

			return Result.Fail<ArticleResponse?>("You are not authorized to edit this article. How did you get here?");

		}

		var article = await _articleService.UpdateArticleAsync(updatedArticle);

		if (article is null)
		{

			return Result.Fail<ArticleResponse?>("The article does not exist.");

		}

		return article.Adapt<ArticleResponse>();

	}

}