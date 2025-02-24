// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     GetArticlesByCurrentUserQueryHandlerTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application.Tests.Unit
// =======================================================

namespace BlazingBlog.Application.Articles.GetArticlesByCurrentUser;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(GetArticlesByCurrentUserQueryHandler))]
public class GetArticlesByCurrentUserQueryHandlerTests
{

	private readonly IArticleService _articleService;

	private readonly IUserService _userService;

	private readonly GetArticlesByCurrentUserQueryHandler _handler;

	public GetArticlesByCurrentUserQueryHandlerTests()
	{

		_articleService = Substitute.For<IArticleService>();
		_userService = Substitute.For<IUserService>();
		_handler = new GetArticlesByCurrentUserQueryHandler(_articleService, _userService);

	}

	[Fact]
	public async Task Handle_ShouldReturnOrderedArticles_WhenUserHasArticles()
	{

		// Arrange
		var userId = Guid.NewGuid().ToString();

		var articles = ArticleGenerator.Generate(2);
		articles[0].UserId = userId;
		articles[1].UserId = userId;
		articles[0].PublishedOn = DateTime.UtcNow.AddDays(-1);

		_userService.GetCurrentUserIdAsync().Returns(userId);
		_articleService.GetArticlesByUserAsync(userId).Returns(articles);

		// Act
		var result = await _handler.Handle(new GetArticlesByCurrentUserQuery(), CancellationToken.None);

		// Assert
		result.Value.Should().BeInDescendingOrder(a => a.PublishedOn);

	}

	[Fact]
	public async Task Handle_ShouldReturnEmptyList_WhenUserHasNoArticles()
	{

		// Arrange
		var userId = Guid.NewGuid().ToString();
		_userService.GetCurrentUserIdAsync().Returns(userId);
		_articleService.GetArticlesByUserAsync(userId).Returns((List<Article>?)null);

		// Act
		var result = await _handler.Handle(new GetArticlesByCurrentUserQuery(), CancellationToken.None);

		// Assert
		result.Value.Should().BeNull();
		result.Success.Should().BeFalse();
		result.Failure.Should().BeTrue();
		result.Error.Should().Be("No articles were found.");

	}

}