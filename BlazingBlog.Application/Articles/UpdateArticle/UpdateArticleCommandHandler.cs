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

	private readonly IArticleService _ArticleService;

	private readonly IUserService _UserService;

	public UpdateArticleCommandHandler(IArticleService articleService, IUserService userService)
	{

		_ArticleService = articleService;
		_UserService = userService;

	}

	public async Task<Result<ArticleResponse?>> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
	{

		var updatedArticle = request.Adapt<Article>();

		if (!await _UserService.CurrentUserCanEditArticlesAsync(updatedArticle.Id))
		{

			return Result.Fail<ArticleResponse?>("You are not authorized to edit this article. How did you get here?");

		}

		var article = await _ArticleService.UpdateArticleAsync(updatedArticle);

		if (article is null)
		{

			return Result.Fail<ArticleResponse?>("The article does not exist.");

		}

		return article.Adapt<ArticleResponse>();

	}

}
