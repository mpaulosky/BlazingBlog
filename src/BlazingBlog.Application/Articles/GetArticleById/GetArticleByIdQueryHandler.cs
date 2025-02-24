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

	public GetArticleByIdQueryHandler(
			IArticleService articleService,
			IUserRepository userRepository)
	{

		_articleService = articleService;
		_userRepository = userRepository;

	}

	public async Task<Result<ArticleResponse?>> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
	{

		var article = await _articleService.GetArticleByIdAsync(request.Id);

		if (article is null) return Result.Fail<ArticleResponse?>("The article does not exist.");

		var articleResponse = article.Adapt<ArticleResponse>();

		if (article.UserId == string.Empty) articleResponse.UserName = "Unknown";
		else
		{

			var author = await _userRepository.GetUserByIdAsync(article.UserId);
			articleResponse.UserName = author?.UserName ?? "Unknown";
			articleResponse.UserId = article.UserId;
			articleResponse.CanEdit = false;

		}

		return articleResponse;

	}

}