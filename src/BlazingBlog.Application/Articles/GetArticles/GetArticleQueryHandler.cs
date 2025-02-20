// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     GetArticleQueryHandler.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application
// =======================================================

namespace BlazingBlog.Application.Articles.GetArticles;

public class GetArticleQueryHandler : IQueryHandler<GetArticleQuery, List<ArticleResponse>>
{

	private readonly IArticleService _articleService;

	private readonly IUserRepository _userRepository;

	private readonly IUserService _userService;

	public GetArticleQueryHandler(IArticleService articleService, IUserRepository userRepository, IUserService userService)
	{

		_articleService = articleService;
		_userRepository = userRepository;
		_userService = userService;

	}

	public async Task<Result<List<ArticleResponse>>> Handle(GetArticleQuery request, CancellationToken cancellationToken)
	{

		var articles = await _articleService.GetAllAsync();

		var response = new List<ArticleResponse>();

		foreach (var article in articles)
		{

			var articleResponse = article.Adapt<ArticleResponse>();

			if (article.UserId is not null)
			{

				var author = await _userRepository.GetUserByIdAsync(article.UserId);

				articleResponse.UserName = author?.UserName ?? "Unknown";

				articleResponse.UserId = article.UserId;

				articleResponse.CanEdit = await _userService
						.CurrentUserCanEditArticlesAsync(article.Id);

			}
			else
			{

				articleResponse.UserName = "Unknown";

			}

			response.Add(articleResponse);

		}

		return response.OrderByDescending(a => a.PublishedOn).ToList();

	}

}
