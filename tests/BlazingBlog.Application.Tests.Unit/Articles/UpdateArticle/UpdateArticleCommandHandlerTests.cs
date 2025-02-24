// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     UpdateArticleCommandHandlerTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application.Tests.Unit
// =======================================================

namespace BlazingBlog.Application.Articles.UpdateArticle;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(UpdateArticleCommandHandler))]
public class UpdateArticleCommandHandlerTests
{

	private readonly IArticleService _articleService;

	private readonly IUserService _userService;

	private readonly UpdateArticleCommandHandler _handler;

	public UpdateArticleCommandHandlerTests()
	{

		_articleService = Substitute.For<IArticleService>();
		_userService = Substitute.For<IUserService>();
		_handler = new UpdateArticleCommandHandler(_articleService, _userService);

	}

	[Fact]
	public async Task Handle_Should_Return_Failure_When_User_Cannot_Edit_Article()
	{

		// Arrange
		var command = new UpdateArticleCommand { Id = 1, Title = "Title", Content = "Content" };
		_userService.CurrentUserCanEditArticlesAsync(command.Id).Returns(false);

		// Act
		var result = await _handler.Handle(command, CancellationToken.None);

		// Assert
		result.Success.Should().BeFalse();
		result.Failure.Should().BeTrue();
		result.Error.Should().Be("You are not authorized to edit this article. How did you get here?");

	}

	[Fact]
	public async Task Handle_Should_Return_Failure_When_Article_Does_Not_Exist()
	{

		// Arrange
		var command = new UpdateArticleCommand { Id = 1, Title = "Title", Content = "Content" };
		_userService.CurrentUserCanEditArticlesAsync(command.Id).Returns(true);
		_articleService.UpdateArticleAsync(Arg.Any<Article>()).Returns((Article?)null);

		// Act
		var result = await _handler.Handle(command, CancellationToken.None);

		// Assert
		result.Success.Should().BeFalse();
		result.Failure.Should().BeTrue();
		result.Error.Should().Be("The article does not exist.");

	}

	[Fact]
	public async Task Handle_Should_Update_Article_Successfully()
	{

		// Arrange
		var article = ArticleGenerator.Generate();

		var command = new UpdateArticleCommand
		{
				Id = article.Id,
				Title = "Updated Title",
				Content = "Updated Content",
				PublishedOn = TestDate,
				IsPublished = true
		};

		_userService.CurrentUserCanEditArticlesAsync(command.Id).Returns(true);
		_articleService.UpdateArticleAsync(Arg.Any<Article>()).Returns(article);

		// Act
		var result = await _handler.Handle(command, CancellationToken.None);

		// Assert
		result.Success.Should().BeTrue();
		result.Value.Should().NotBeNull();
		result.Value.Should().BeEquivalentTo(article, options => options
				.Excluding(r => r.ModifiedOn));
		result.Value!.Value.ModifiedOn.Should().NotBeNull();

	}

}