// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     DeleteArticleCommandHandlerTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application.Tests.Unit
// =======================================================

namespace BlazingBlog.Application.Articles.DeleteArticle;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(DeleteArticleCommandHandler))]
public class DeleteArticleCommandHandlerTests
{

	[Fact]
	public async Task Handle_ShouldReturnFailResult_WhenUserNotAuthorized()
	{

		// Arrange
		var articleService = Substitute.For<IArticleService>();
		var userService = Substitute.For<IUserService>();
		userService.CurrentUserCanEditArticlesAsync(Arg.Any<int>()).Returns(false);

		var handler = new DeleteArticleCommandHandler(articleService, userService);
		var command = new DeleteArticleCommand { Id = 1 };

		// Act
		var result = await handler.Handle(command, CancellationToken.None);

		// Assert
		result.Success.Should().BeFalse();
		result.Error.Should().Contain("You are not authorized to delete this article. How did you get here?");

	}

	[Fact]
	public async Task Handle_ShouldReturnOkResult_WhenArticleDeletedSuccessfully()
	{

		// Arrange
		var articleService = Substitute.For<IArticleService>();
		var userService = Substitute.For<IUserService>();
		userService.CurrentUserCanEditArticlesAsync(Arg.Any<int>()).Returns(true);
		articleService.DeleteArticleAsync(Arg.Any<int>()).Returns(true);

		var handler = new DeleteArticleCommandHandler(articleService, userService);
		var command = new DeleteArticleCommand { Id = 1 };

		// Act
		var result = await handler.Handle(command, CancellationToken.None);

		// Assert
		result.Success.Should().BeTrue();

	}

	[Fact]
	public async Task Handle_ShouldReturnFailResult_WhenArticleDoesNotExist()
	{

		// Arrange
		var articleService = Substitute.For<IArticleService>();
		var userService = Substitute.For<IUserService>();
		userService.CurrentUserCanEditArticlesAsync(Arg.Any<int>()).Returns(true);
		articleService.DeleteArticleAsync(Arg.Any<int>()).Returns(false);

		var handler = new DeleteArticleCommandHandler(articleService, userService);
		var command = new DeleteArticleCommand { Id = 1 };

		// Act
		var result = await handler.Handle(command, CancellationToken.None);

		// Assert
		result.Success.Should().BeFalse();
		result.Error.Should().Contain("The article does not exist");

	}

}