// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     GetArticleByIdQueryHandlerTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application.Tests.Unit
// =======================================================

namespace BlazingBlog.Application.Articles.GetArticleById;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(GetArticleByIdQueryHandler))]
public class GetArticleByIdQueryHandlerTests
{
	
	private readonly IArticleService _articleService;

	private readonly IUserRepository _userRepository;

	private readonly IUserService _userService;

	private readonly GetArticleByIdQueryHandler _handler;

	public GetArticleByIdQueryHandlerTests()
	{

		_articleService = Substitute.For<IArticleService>();
		_userRepository = Substitute.For<IUserRepository>();
		_userService = Substitute.For<IUserService>();
		_handler = new GetArticleByIdQueryHandler(_articleService, _userRepository, _userService);

	}

	[Fact]
	public async Task Handle_ShouldReturnArticleResponse_WhenArticleExists()
	{

		// Arrange
		var user = Helpers.Helpers.UserGenerator.Generate();
		var article = Helpers.Helpers.ArticleGenerator.Generate();
		article.UserId = user.Id;
		
		var query = new GetArticleByIdQuery { Id = article.Id };
		
		var articleResponse = article.Adapt<ArticleResponse>();
		
		_articleService.GetArticleByIdAsync(query.Id).Returns(article);
		_userRepository.GetUserByIdAsync(article.UserId).Returns(user);
		_userService.CurrentUserCanEditArticlesAsync(article.Id).Returns(true);

		// Act
		var result = await _handler.Handle(query, CancellationToken.None);

		// Assert
		result.Should().NotBeNull();
		result.Value.Should().BeEquivalentTo(articleResponse, options => options
						.Excluding(r => r.CanEdit)
						.Excluding(r => r.UserName));

	}

	[Fact]
	public async Task Handle_ShouldReturnNull_WhenArticleDoesNotExist()
	{

		// Arrange
		var article = Helpers.Helpers.ArticleGenerator.Generate();
		
		var query = new GetArticleByIdQuery { Id = article.Id };

		// Act
		var result = await _handler.Handle(query, CancellationToken.None);

		// Assert
		result.Success.Should().BeFalse();
		result.Failure.Should().BeTrue();
		result.Error.Should().Be("The article does not exist.");

	}

	[Fact]
	public async Task Handle_ShouldReturnArticleResponseWithUnknownUser_WhenUserDoesNotExist()
	{

		// Arrange
		var article = Helpers.Helpers.ArticleGenerator.Generate();
		var articleResponse = article.Adapt<ArticleResponse>();
		articleResponse.UserName = "Unknown";
		articleResponse.CanEdit = false;
		var query = new GetArticleByIdQuery { Id = article.Id };
		_articleService.GetArticleByIdAsync(query.Id).Returns(article);

		_userRepository.GetUserByIdAsync(Arg.Any<string>()).Returns((User)null!);

		// Act
		var result = await _handler.Handle(query, CancellationToken.None);

		// Assert
		result.Should().NotBeNull();
		result.Value.Should().BeEquivalentTo(articleResponse);

	}

}