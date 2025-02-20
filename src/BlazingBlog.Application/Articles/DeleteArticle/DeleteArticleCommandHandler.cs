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

	private readonly IArticleService _articleService;

	private readonly IUserService _userService;


	public DeleteArticleCommandHandler(IArticleService articleService, IUserService userService)
	{

		_articleService = articleService;
		_userService = userService;

	}

	public async Task<Result> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
	{

		if (!await _userService.CurrentUserCanEditArticlesAsync(request.Id))
		{

			return Result.Fail<ArticleResponse?>("You are not authorized to delete this article. How did you get here?");

		}

		var deleted = await _articleService.DeleteArticleAsync(request.Id);

		if (deleted) return Result.Ok();

			return Result.Fail("The article does not exist");

	}

}
