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

	private readonly IUserRepository _userRepository;

	private readonly IArticleService _articleService;

	private readonly GetArticleByIdQueryHandler _handler;


	public GetArticleByIdQueryHandlerTests()
	{

		_userRepository = Substitute.For<IUserRepository>();

		_articleService = Substitute.For<IArticleService>();

		_handler = new GetArticleByIdQueryHandler(_articleService, _userRepository);

	}

	[Fact]
	public async Task Handle_ShouldReturnArticleResponse_WhenArticleExists()
	{

		// Arrange
		var article = ArticleGenerator.Generate();
		var user = UserGenerator.Generate();
		user.Id = article.UserId;

		var query = new GetArticleByIdQuery { Id = article.Id };

		var articleResponse = article.Adapt<ArticleResponse>();
		articleResponse.UserName = user.UserName ?? string.Empty;
		articleResponse.CanEdit = false;

		_userRepository.GetUserByIdAsync(article.UserId).Returns(user);
		_articleService.GetArticleByIdAsync(query.Id).Returns(article);

		// Act
		ArticleResponse? result = (await _handler.Handle(query, CancellationToken.None)).Value;

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
	public async Task Handle_ShouldReturnArticleResponseWithUnknownUser_WhenArticleHasNoUserId()
	{

		// Arrange
		var article = ArticleGenerator.Generate();
		article.UserId = string.Empty;
		
		var articleResponse = article.Adapt<ArticleResponse>();
		articleResponse.UserName = "Unknown";
		articleResponse.CanEdit = false;
		
		var query = new GetArticleByIdQuery { Id = article.Id };
		
		_articleService.GetArticleByIdAsync(query.Id).Returns(article);

		// Act
		var result = await _handler.Handle(query, CancellationToken.None);

		// Assert
		result.Should().NotBeNull();
		result.Value.Should().BeEquivalentTo(articleResponse);

	}

	[Fact]
	public async Task Handle_ShouldReturnFailure_WhenArticleDoesNotExist()
	{

		// Arrange
		var query = new GetArticleByIdQuery { Id = 1 };

		// Act
		var result = await _handler.Handle(query, CancellationToken.None);

		// Assert
		result.Success.Should().BeFalse();
		result.Failure.Should().BeTrue();
		result.Error.Should().Be("The article does not exist.");

	}

}