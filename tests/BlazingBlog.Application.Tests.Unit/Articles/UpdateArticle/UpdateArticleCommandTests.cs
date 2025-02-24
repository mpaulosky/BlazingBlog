// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     UpdateArticleCommandTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application.Tests.Unit
// =======================================================

namespace BlazingBlog.Application.Articles.UpdateArticle;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(UpdateArticleCommand))]
public class UpdateArticleCommandTests
{

	[Fact]
	public void UpdateArticleCommand_Should_SetPropertiesCorrectly()
	{

		// Arrange
		var command = new UpdateArticleCommand
		{
				Id = 1,
				Title = "Updated Title",
				Content = "Updated Content",
				PublishedOn = TestDate,
				ModifiedOn = TestDate,
				IsPublished = true
		};

		// Act & Assert
		command.Id.Should().Be(1);
		command.Title.Should().Be("Updated Title");
		command.Content.Should().Be("Updated Content");
		command.PublishedOn.Should().Be(TestDate);
		command.IsPublished.Should().BeTrue();
		command.ModifiedOn.Should().Be(TestDate);

	}

}