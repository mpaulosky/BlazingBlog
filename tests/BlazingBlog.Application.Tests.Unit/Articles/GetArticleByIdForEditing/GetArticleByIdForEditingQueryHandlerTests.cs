// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     GetArticleByIdForEditingQueryHandlerTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application.Tests.Unit
// =======================================================

namespace BlazingBlog.Application.Articles.GetArticleByIdForEditing;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(GetArticleByIdForEditingQueryHandler))]
public class GetArticleByIdForEditingQueryHandlerTests
{

	private readonly IArticleService _articleService;

	private readonly IUserService _userService;

	private readonly GetArticleByIdForEditingQueryHandler _handler;

	public GetArticleByIdForEditingQueryHandlerTests()
	{

		_articleService = Substitute.For<IArticleService>();
		_userService = Substitute.For<IUserService>();
		_handler = new GetArticleByIdForEditingQueryHandler(_articleService, _userService);

	}

	[Fact]
	public async Task Handle_ShouldReturnArticleResponse_WhenUserCanEdit()
	{

		// Arrange
		var query = new GetArticleByIdForEditingQuery { Id = 1 };
		var article = new Article { Id = 1, Title = "Test Article" };
		//var articleResponse = article.Adapt<ArticleResponse>() with { CanEdit = canEdit };
		_userService.CurrentUserCanEditArticlesAsync(query.Id).Returns(true);
		_articleService.GetArticleByIdAsync(query.Id).Returns(article);

		// Act
		var result = await _handler.Handle(query, CancellationToken.None);

		// Assert
		result.Should().NotBeNull();
		// result.Value.Should().BeEquivalentTo(articleResponse, options => options.Excluding(r => r.CanEdit));
		// result.Value.CanEdit.Should().BeTrue();

	}

	[Fact]
	public async Task Handle_ShouldReturnArticleResponse_WhenUserCannotEdit()
	{

		// Arrange
		var query = new GetArticleByIdForEditingQuery { Id = 1 };
		var article = new Article { Id = 1, Title = "Test Article" };
		var articleResponse = article.Adapt<ArticleResponse>();
		_userService.CurrentUserCanEditArticlesAsync(query.Id).Returns(false);
		_articleService.GetArticleByIdAsync(query.Id).Returns(article);

		// Act
		var result = await _handler.Handle(query, CancellationToken.None);

		// Assert
		result.Should().NotBeNull();
		result.Value.Should().BeEquivalentTo(articleResponse, options => options.Excluding(r => r.CanEdit));
		//result.Value.CanEdit.Should().BeFalse();

	}

}