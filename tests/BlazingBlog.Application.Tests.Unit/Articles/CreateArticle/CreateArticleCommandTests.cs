// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     CreateArticleCommandTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application.Tests.Unit
// =======================================================

namespace BlazingBlog.Application.Articles.CreateArticle;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(CreateArticleCommand))]
public class CreateArticleCommandTests
{

	private static readonly DateTimeOffset TestDate = new DateTimeOffset(2025, 1, 1, 0, 0, 0, TimeSpan.Zero);

	[Fact]
	public void METHOD()
	{

		// Arrange
		var command = new CreateArticleCommand
		{
				Title = "Sample Title",
				Content = "Sample Content",
				PublishedOn = TestDate,
				IsPublished = true
		};

		// Act
		var result = Result<ArticleResponse>.Ok(new ArticleResponse(
				Id: 1,
				Title: command.Title,
				Content: command.Content,
				CreatedOn: TestDate,
				PublishedOn: command.PublishedOn,
				ModifiedOn: null,
				IsPublished: command.IsPublished,
				UserName: "TestUser",
				UserId: "123",
				CanEdit: true
		));

		// Assert
		result.Success.Should().BeTrue();
		result.Value.Should().NotBeNull();
		result.Value!.Title.Should().Be(command.Title);
		result.Value.Content.Should().Be(command.Content);
		result.Value.PublishedOn.Should().Be(command.PublishedOn);
		result.Value.IsPublished.Should().Be(command.IsPublished);
		result.Value.UserName.Should().Be("TestUser");
		result.Value.UserId.Should().Be("123");
		result.Value.CanEdit.Should().BeTrue();

	}

}