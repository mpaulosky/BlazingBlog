// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     DeleteArticleCommandHandler.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application
// =======================================================

namespace BlazingBlog.Application.Articles.DeleteArticle;

public class DeleteArticleCommandHandler : ICommandHandler<DeleteArticleCommand>
{

	private readonly IArticleService _ArticleService;

	private readonly IUserService _UserService;


	public DeleteArticleCommandHandler(IArticleService articleService, IUserService userService)
	{

		_ArticleService = articleService;
		_UserService = userService;

	}

	public async Task<Result> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
	{

		if (!await _UserService.CurrentUserCanEditArticlesAsync(request.Id))
		{

			return Result.Fail<ArticleResponse?>("You are not authorized to delete this article. How did you get here?");

		}

		var deleted = await _ArticleService.DeleteArticleAsync(request.Id);

		if (deleted) return Result.Ok();

			return Result.Fail("The article does not exist");

	}

}
