// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     TogglePublishArticleCommandTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application.Tests.Unit
// =======================================================

namespace BlazingBlog.Application.TogglePublishArticle;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(TogglePublishArticleCommand))]
public class TogglePublishArticleCommandTests
{

	[Fact]
	public void TogglePublishArticleCommand_Should_SetPropertiesCorrectly()
	{

		// Arrange
		var command = new TogglePublishArticleCommand
		{
				ArticleId = 1
		};

		// Act & Assert
		command.ArticleId.Should().Be(1);

	}

}