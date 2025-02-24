// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     TogglePublishArticleCommandHandlerTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application.Tests.Unit
// =======================================================

namespace BlazingBlog.Application.Articles.TogglePublishArticle;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(TogglePublishArticleCommandHandler))]
public class TogglePublishArticleCommandHandlerTests
{

	private readonly IArticleService _articleService;

	private readonly IUserService _userService;

	private readonly TogglePublishArticleCommandHandler _handler;

	public TogglePublishArticleCommandHandlerTests()
	{

		_articleService = Substitute.For<IArticleService>();
		_userService = Substitute.For<IUserService>();
		_handler = new TogglePublishArticleCommandHandler(_articleService, _userService);

	}

	[Fact]
	public async Task Handle_Should_Return_Failure_When_User_Cannot_Edit_Article()
	{

		// Arrange
		var command = new TogglePublishArticleCommand { ArticleId = 1 };
		_userService.CurrentUserCanEditArticlesAsync(command.ArticleId).Returns(false);

		// Act
		var result = await _handler.Handle(command, CancellationToken.None);

		// Assert
		result.Success.Should().BeFalse();
		result.Error.Should().Be("You are not authorized to edit this article. How did you get here?");

	}

	[Fact]
	public async Task Handle_Should_Return_Failure_When_Article_Does_Not_Exist()
	{

		// Arrange
		var command = new TogglePublishArticleCommand { ArticleId = 1 };
		_userService.CurrentUserCanEditArticlesAsync(command.ArticleId).Returns(true);
		_articleService.GetArticleByIdAsync(command.ArticleId).Returns((Article?)null);

		// Act
		var result = await _handler.Handle(command, CancellationToken.None);

		// Assert
		result.Success.Should().BeFalse();
		result.Failure.Should().BeTrue();
		result.Error.Should().Be("The article does not exist.");

	}

	[Fact]
	public async Task Handle_Should_Toggle_Article_Publish_Status()
	{

		// Arrange

		var article = ArticleGenerator.Generate();
		article.IsPublished = false;
		article.PublishedOn = null;
		var command = new TogglePublishArticleCommand { ArticleId = article.Id};
		_userService.CurrentUserCanEditArticlesAsync(command.ArticleId).Returns(true);
		_articleService.GetArticleByIdAsync(command.ArticleId).Returns(article);
		_articleService.UpdateArticleAsync(article).Returns(article);

		// Act
		var result = await _handler.Handle(command, CancellationToken.None);

		// Assert
		result.Success.Should().BeTrue();
		article.IsPublished.Should().BeTrue();
		article.PublishedOn.Should().NotBeNull();
		article.ModifiedOn.Should().NotBeNull();

	}

	[Fact]
	public async Task Handle_Should_Return_Failure_When_Update_Fails()
	{

		// Arrange
		var article = ArticleGenerator.Generate();
		var command = new TogglePublishArticleCommand { ArticleId = article.Id};
		_userService.CurrentUserCanEditArticlesAsync(command.ArticleId).Returns(true);
		_articleService.GetArticleByIdAsync(command.ArticleId).Returns(article);
		_articleService.UpdateArticleAsync(article).Returns((Article?)null);

		// Act
		var result = await _handler.Handle(command, CancellationToken.None);

		// Assert
		result.Success.Should().BeFalse();
		result.Failure.Should().BeTrue();
		result.Error.Should().Be("Failed to update the article.");

	}

}