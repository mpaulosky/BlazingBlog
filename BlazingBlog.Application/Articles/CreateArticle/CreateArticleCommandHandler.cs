// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     CreateArticleCommandHandler.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application
// =======================================================

namespace BlazingBlog.Application.Articles.CreateArticle;

public class CreateArticleCommandHandler : ICommandHandler<CreateArticleCommand, ArticleResponse>
{

	private readonly IArticleService _ArticleService;

	private readonly IUserService _UserService;

	public CreateArticleCommandHandler(
			IArticleService articleService,
			IUserService userService)
	{

		_ArticleService = articleService;
		_UserService = userService;

	}

	public async Task<Result<ArticleResponse>> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
	{

		try
		{

			var newArticle = request.Adapt<Article>();

			newArticle.UserId = await _UserService.GetCurrentUserIdAsync();

			if (!await _UserService.CurrentUserCanCreateArticlesAsync())
			{

				return FailingResult();

			}


			var article = await _ArticleService.CreateAsync(newArticle);

			return article.Adapt<ArticleResponse>();

		}
		catch (UserNotAuthorizedException)
		{

			return FailingResult();

		}

	}

	private Result<ArticleResponse> FailingResult()
	{

		return Result.Fail<ArticleResponse>("You're not allowed to create articles, Sorry!");

	}

}
