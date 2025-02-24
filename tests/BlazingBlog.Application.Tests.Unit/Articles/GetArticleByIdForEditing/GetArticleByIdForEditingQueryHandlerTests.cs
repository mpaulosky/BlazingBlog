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
	
	private readonly IUserRepository _userRepository;

	private readonly IUserService _userService;

	private readonly GetArticleByIdForEditingQueryHandler _handler;

	public GetArticleByIdForEditingQueryHandlerTests()
	{

		_articleService = Substitute.For<IArticleService>();
		_userRepository = Substitute.For<IUserRepository>();
		_userService = Substitute.For<IUserService>();
		_handler = new GetArticleByIdForEditingQueryHandler(_articleService, _userRepository, _userService);

	}

	[Fact]
	public async Task Handle_ShouldReturnArticleResponse_WhenUserCanEdit()
	{

		// Arrange
		var article = ArticleGenerator.Generate();
		var user = UserGenerator.Generate();
		user.Id = article.UserId;

		var query = new GetArticleByIdForEditingQuery { Id = article.Id };
		
		var articleResponse = article.Adapt<ArticleResponse>();
		articleResponse.UserName = user.UserName ?? string.Empty;
		articleResponse.CanEdit = true;
		
		_userService.CurrentUserCanEditArticlesAsync(query.Id).Returns(true);
		_userRepository.GetUserByIdAsync(article.UserId).Returns(user);
		_articleService.GetArticleByIdAsync(query.Id).Returns(article);

		// Act
		var result = (await _handler.Handle(query, CancellationToken.None)).Value;

		// Assert
		result.Should().NotBeNull();
		result!.Value.Id.Should().Be(articleResponse.Id);
		result.Value.Title.Should().Be(articleResponse.Title);
		result.Value.Content.Should().Be(articleResponse.Content);
		result.Value.CreatedOn.Should().Be(articleResponse.CreatedOn);
		result.Value.PublishedOn.Should().Be(articleResponse.PublishedOn);
		result.Value.IsPublished.Should().Be(articleResponse.IsPublished);
		result.Value.ModifiedOn.Should().Be(articleResponse.ModifiedOn);
		result.Value.UserName.Should().Be(articleResponse.UserName);
		result.Value.UserId.Should().Be(articleResponse.UserId);
		result.Value.CanEdit.Should().Be(articleResponse.CanEdit);
		result.Value.ModifiedOn.Should().NotBeNull();
		result.Value.UserName.Should().Be(articleResponse.UserName);

	}

	[Fact]
	public async Task Handle_ShouldReturnArticleResponse_WhenUserCannotEdit()
	{

		// Arrange
		var article = ArticleGenerator.Generate();
		var user = UserGenerator.Generate();
		user.Id = article.UserId;

		var query = new GetArticleByIdForEditingQuery { Id = article.Id };

		var articleResponse = article.Adapt<ArticleResponse>();
		articleResponse.UserName = user.UserName ?? string.Empty;
		articleResponse.CanEdit = false;

		_userService.CurrentUserCanEditArticlesAsync(query.Id).Returns(false);
		_userRepository.GetUserByIdAsync(article.UserId).Returns(user);
		_articleService.GetArticleByIdAsync(query.Id).Returns(article);

		// Act
		var result = (await _handler.Handle(query, CancellationToken.None)).Value;

		// Assert
		result.Should().NotBeNull();
		result!.Value.Should().BeEquivalentTo(articleResponse);

	}

}