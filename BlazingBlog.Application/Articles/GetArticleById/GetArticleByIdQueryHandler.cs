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

	private readonly IArticleService _ArticleService;

	private readonly IUserRepository _UserRepository;

	private readonly IUserService _UserService;

	public GetArticleByIdQueryHandler(IArticleService articleService, IUserRepository userRepository, IUserService userService)
	{

		_ArticleService = articleService;
		_UserRepository = userRepository;
		_UserService = userService;

	}

	public async Task<Result<ArticleResponse?>> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
	{

		var article = await _ArticleService.GetArticleByIdAsync(request.Id);

		if (article is null) return Result.Fail<ArticleResponse?>("The article does not exist.");

		var articleResponse = article.Adapt<ArticleResponse>();

		if (article.UserId is not null)
		{

			var author = await _UserRepository.GetUserByIdAsync(article.UserId);

			articleResponse.UserName = author?.UserName ?? "Unknown";

			articleResponse.UserId = article.UserId;

			articleResponse.CanEdit = await _UserService
					.CurrentUserCanEditArticlesAsync(article.Id);

		}
		else
		{

			articleResponse.UserName = "Unknown";

		}

		return articleResponse;

	}

}
