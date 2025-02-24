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

	private readonly IArticleService _articleService;

	private readonly IUserService _userService;

	private readonly DeleteArticleCommandHandler _handler;


	public DeleteArticleCommandHandlerTests()
	{

		_articleService = Substitute.For<IArticleService>();
		
		_userService = Substitute.For<IUserService>();

		_handler = new DeleteArticleCommandHandler(_articleService, _userService);

	}

	[Fact]
	public async Task Handle_ShouldReturnFailResult_WhenUserNotAuthorized()
	{

		// Arrange
		_userService.CurrentUserCanEditArticlesAsync(Arg.Any<int>()).Returns(false);

		var command = new DeleteArticleCommand { Id = 1 };

		// Act
		var result = await _handler.Handle(command, CancellationToken.None);

		// Assert
		result.Success.Should().BeFalse();
		result.Error.Should().Contain("You are not authorized to delete this article. How did you get here?");

	}

	[Fact]
	public async Task Handle_ShouldReturnOkResult_WhenArticleDeletedSuccessfully()
	{

		// Arrange
		_userService.CurrentUserCanEditArticlesAsync(Arg.Any<int>()).Returns(true);
		_articleService.DeleteArticleAsync(Arg.Any<int>()).Returns(true);

		var command = new DeleteArticleCommand { Id = 1 };

		// Act
		var result = await _handler.Handle(command, CancellationToken.None);

		// Assert
		result.Success.Should().BeTrue();

	}

	[Fact]
	public async Task Handle_ShouldReturnFailResult_WhenArticleDoesNotExist()
	{

		// Arrange
		_userService.CurrentUserCanEditArticlesAsync(Arg.Any<int>()).Returns(true);
		_articleService.DeleteArticleAsync(Arg.Any<int>()).Returns(false);

		var command = new DeleteArticleCommand { Id = 1 };

		// Act
		var result = await _handler.Handle(command, CancellationToken.None);

		// Assert
		result.Success.Should().BeFalse();
		result.Error.Should().Contain("The article does not exist");

	}

}