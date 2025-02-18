// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     GetArticlesByCurrentUserQueryHandler.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application
// =======================================================

namespace BlazingBlog.Application.Articles.GetArticlesByCurrentUser;

public class GetArticlesByCurrentUserQueryHandler : IQueryHandler<GetArticlesByCurrentUserQuery, List<ArticleResponse>>
{

	private readonly IArticleService _ArticleService;

	private readonly IUserService _UserService;

	public GetArticlesByCurrentUserQueryHandler(IArticleService articleService, IUserService userService)
	{

		_ArticleService = articleService;
		_UserService = userService;

	}

	public async Task<Result<List<ArticleResponse>>> Handle(GetArticlesByCurrentUserQuery request, CancellationToken cancellationToken)
	{

		var userId = await _UserService.GetCurrentUserIdAsync();

		var articles = await _ArticleService.GetArticlesByUserAsync(userId);

		var response = articles.Adapt<List<ArticleResponse>>();

		return response.OrderByDescending(a => a.PublishedOn).ToList();

	}

}
