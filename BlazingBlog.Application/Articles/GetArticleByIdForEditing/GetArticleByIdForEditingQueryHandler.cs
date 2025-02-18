// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     GetArticleByIdForEditingQueryHandler.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application
// =======================================================

namespace BlazingBlog.Application.Articles.GetArticleByIdForEditing;

public class GetArticleByIdForEditingQueryHandler : IQueryHandler<GetArticleByIdForEditingQuery, ArticleResponse?>
{

	private readonly IArticleService _ArticleService;

	private readonly IUserService _UserService;

	public GetArticleByIdForEditingQueryHandler(
			IArticleService articleService,
			IUserService userService)
	{

		_ArticleService = articleService;
		_UserService = userService;

	}

	public async Task<Result<ArticleResponse?>> Handle(GetArticleByIdForEditingQuery request, CancellationToken cancellationToken)
	{

		var canEdit = await _UserService.CurrentUserCanEditArticlesAsync(request.Id);

		//if (!canEdit) return Result.Fail<ArticleResponse?>("You're not allowed to edit this article.");

		var article = await _ArticleService.GetArticleByIdAsync(request.Id);

		var articleResponse = article.Adapt<ArticleResponse>();

		articleResponse.CanEdit = canEdit;

		return articleResponse;

	}

}
