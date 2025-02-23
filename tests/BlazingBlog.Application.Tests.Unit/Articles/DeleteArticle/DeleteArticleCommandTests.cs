// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     DeleteArticleCommandTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application.Tests.Unit
// =======================================================

namespace BlazingBlog.Application.Articles.DeleteArticle;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(DeleteArticleCommand))]
public class DeleteArticleCommandTests
{

	[Fact]
	public void DeleteArticleCommand_ShouldSetIdCorrectly()
	{

		// Arrange
		var command = new DeleteArticleCommand();

		// Act
		command.Id = 123;

		// Assert
		command.Id.Should().Be(123);

	}

	[Fact]
	public void DeleteArticleCommand_ShouldInitializeWithDefaultValues()
	{

		// Arrange & Act
		var command = new DeleteArticleCommand();

		// Assert
		command.Id.Should().Be(0);

	}

}