// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     GetArticlesByCurrentUserQueryHandler.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application
// =======================================================

namespace BlazingBlog.Application.Articles.GetArticlesByCurrentUser;

public class GetArticlesByCurrentUserQueryHandler : IQueryHandler<GetArticlesByCurrentUserQuery, List<ArticleResponse>?>
{

	private readonly IArticleService _articleService;

	private readonly IUserService _userService;

	public GetArticlesByCurrentUserQueryHandler(IArticleService articleService, IUserService userService)
	{

		_articleService = articleService;
		_userService = userService;

	}

	public async Task<Result<List<ArticleResponse>?>> Handle(GetArticlesByCurrentUserQuery request, CancellationToken cancellationToken)
	{

		var userId = await _userService.GetCurrentUserIdAsync();

		var articles = await _articleService.GetArticlesByUserAsync(userId);
		
		if (articles is null) return Result.Fail<List<ArticleResponse>?>("No articles were found.");
		
		var response = articles.Adapt<List<ArticleResponse>>();

		return response.OrderByDescending(a => a.PublishedOn).ToList();

	}

}