// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     GetArticleByIdQueryHandler.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application
// =======================================================

namespace BlazingBlog.Application.Articles.GetArticleById;

public class GetArticleByIdQueryHandler : IQueryHandler<GetArticleByIdQuery, ArticleResponse?>
{

	private readonly IArticleService _articleService;

	private readonly IUserRepository _userRepository;

	private readonly IUserService _userService;

	public GetArticleByIdQueryHandler(
			IArticleService articleService,
			IUserRepository userRepository,
			IUserService userService)
	{

		_articleService = articleService;
		_userRepository = userRepository;
		_userService = userService;

	}

	public async Task<Result<ArticleResponse?>> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
	{

		var article = await _articleService.GetArticleByIdAsync(request.Id);

		if (article is null) return Result.Fail<ArticleResponse?>("The article does not exist.");

		var articleResponse = article.Adapt<ArticleResponse>();

		var author = await _userRepository.GetUserByIdAsync(article.UserId);

		if (article.UserId == string.Empty || author is null)
		{

			articleResponse.UserName = "Unknown";
			articleResponse.CanEdit = false;

		}
		else
		{

			articleResponse.UserName = author.UserName!;
			articleResponse.UserId = article.UserId;
			articleResponse.CanEdit = await _userService.CurrentUserCanEditArticlesAsync(article.Id);

		}

		return articleResponse;

	}

}