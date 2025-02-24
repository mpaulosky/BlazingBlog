// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     CreateArticleCommandHandlerTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application.Tests.Unit
// =======================================================

namespace BlazingBlog.Application.Articles.CreateArticle;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(CreateArticleCommandHandler))]
public class CreateArticleCommandHandlerTests
{

	private readonly IArticleService _articleService;

	private readonly IUserService _userService;

	private readonly CreateArticleCommandHandler _handler;

	public CreateArticleCommandHandlerTests()
	{

		_articleService = Substitute.For<IArticleService>();
		_userService = Substitute.For<IUserService>();
		_handler = new CreateArticleCommandHandler(_articleService, _userService);

	}

	[Fact]
	public async Task Handle_ShouldReturnSuccessResult_WhenUserCanCreateArticles()
	{

		// Arrange
		var command = new CreateArticleCommand
		{
				Title = "Sample Title",
				Content = "Sample Content",
				PublishedOn = TestDate,
				IsPublished = true
		};

		var article = new Article
		{
				Id = 1,
				Title = command.Title,
				Content = command.Content,
				PublishedOn = command.PublishedOn,
				IsPublished = command.IsPublished,
				UserId = "123"
		};

		_userService.GetCurrentUserIdAsync().Returns("123");
		_userService.CurrentUserCanCreateArticlesAsync().Returns(true);
		_articleService.CreateAsync(Arg.Any<Article>()).Returns(article);

		// Act
		var result = await _handler.Handle(command, CancellationToken.None);

		// Assert
		result.Success.Should().BeTrue();
		result.Value.Should().NotBeNull();
		result.Value.Title.Should().Be(command.Title);
		result.Value.Content.Should().Be(command.Content);
		result.Value.PublishedOn.Should().Be(command.PublishedOn);
		result.Value.IsPublished.Should().Be(command.IsPublished);
		result.Value.UserId.Should().Be("123");

	}

	[Fact]
	public async Task Handle_ShouldReturnFailingResult_WhenUserCannotCreateArticles()
	{

		// Arrange
		var command = new CreateArticleCommand
		{
				Title = "Sample Title",
				Content = "Sample Content",
				PublishedOn = TestDate,
				IsPublished = true
		};

		_userService.GetCurrentUserIdAsync().Returns("123");
		_userService.CurrentUserCanCreateArticlesAsync().Returns(false);

		// Act
		var result = await _handler.Handle(command, CancellationToken.None);

		// Assert
		result.Success.Should().BeFalse();
		result.Error.Should().Be("You're not allowed to create articles, Sorry!");

	}

	[Fact]
	public async Task Handle_ShouldReturnFailingResult_WhenUserNotAuthorized()
	{

		// Arrange
		var command = new CreateArticleCommand
		{
				Title = "Sample Title",
				Content = "Sample Content",
				PublishedOn = TestDate,
				IsPublished = true
		};

		_userService.GetCurrentUserIdAsync().Returns("123");
		_userService.CurrentUserCanCreateArticlesAsync().Throws(new UserNotAuthorizedException());

		// Act
		var result = await _handler.Handle(command, CancellationToken.None);

		// Assert
		result.Success.Should().BeFalse();
		result.Error.Should().Be("You're not allowed to create articles, Sorry!");

	}

}