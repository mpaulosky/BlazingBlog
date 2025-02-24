// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     GetArticleQueryHandlerTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application.Tests.Unit
// =======================================================

namespace BlazingBlog.Application.Articles.GetArticles;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(GetArticleQueryHandler))]
public class GetArticleQueryHandlerTests
{

	private readonly IArticleService _articleService;

	private readonly IUserRepository _userRepository;

	private readonly IUserService _userService;

	private readonly GetArticleQueryHandler _handler;

	public GetArticleQueryHandlerTests()
	{

		_articleService = Substitute.For<IArticleService>();
		_userRepository = Substitute.For<IUserRepository>();
		_userService = Substitute.For<IUserService>();
		_handler = new GetArticleQueryHandler(_articleService, _userRepository, _userService);

	}

	[Fact]
	public async Task Handle_Should_Return_OrderedArticleResponses_When_Successful()
	{

		// Arrange
		var articles = ArticleGenerator.Generate(3);
		articles[1].UserId = string.Empty;
		
		var users = UserGenerator.Generate(3);
		users[0].Id = articles[0].UserId!;
		users[1].Id = articles[1].UserId!;
		users[2].Id = articles[2].UserId!;

		_articleService.GetAllAsync().Returns(articles);

		_userRepository.GetUserByIdAsync(articles[0].UserId!).Returns(users[0]);
		_userRepository.GetUserByIdAsync(articles[1].UserId!).Returns((User?)null);
		_userRepository.GetUserByIdAsync(articles[2].UserId!).Returns(users[2]);

		_userService.CurrentUserCanEditArticlesAsync(articles[0].Id!).Returns(true);
		_userService.CurrentUserCanEditArticlesAsync(articles[1].Id!).Returns(false);
		_userService.CurrentUserCanEditArticlesAsync(articles[2].Id!).Returns(true);

		GetArticleQuery query = new GetArticleQuery();

		// Act
		Result<List<ArticleResponse>> result = await _handler.Handle(query, CancellationToken.None);

		// Assert
		result.Success.Should().BeTrue();
		result.Value.Should().HaveCount(3);
		result.Value![0].Id.Should().Be(articles[0].Id);
		result.Value[1].Id.Should().Be(articles[1].Id);
		result.Value[2].Id.Should().Be(articles[2].Id);
		result.Value[0].UserName.Should().Be(users[0].UserName);
		result.Value[1].UserName.Should().Be("Unknown");
		result.Value[2].UserName.Should().Be(users[2].UserName);
		result.Value[0].CanEdit.Should().BeTrue();
		result.Value[1].CanEdit.Should().BeFalse();
		result.Value[2].CanEdit.Should().BeTrue();

	}

}