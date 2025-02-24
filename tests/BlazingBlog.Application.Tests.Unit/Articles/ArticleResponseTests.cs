// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     ArticleResponseTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application.Tests.Unit
// =======================================================

namespace BlazingBlog.Application.Articles;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(ArticleResponse))]
public class ArticleResponseTests
{

	[Fact]
	public void ArticleResponse_ShouldHaveCorrectValues()
	{

		// Arrange
		const int id = 1;
		const string title = "Sample Title";
		const string content = "Sample Content";
		DateTimeOffset createdOn = TestDate;
		DateTimeOffset? publishedOn =  TestDate;
		const bool isPublished = true;
		DateTimeOffset? modifiedOn = TestDate;
		const string userName = "Tester";
		const string userId = "user123";
		const bool canEdit = true;

		// Act
		var articleResponse =
				new ArticleResponse(id, title, content, createdOn, publishedOn, modifiedOn, isPublished, userName, userId, canEdit);

		// Assert
		articleResponse.Id.Should().Be(id);
		articleResponse.Title.Should().Be(title);
		articleResponse.Content.Should().Be(content);
		articleResponse.CreatedOn.Should().Be(createdOn);
		articleResponse.PublishedOn.Should().Be(publishedOn);
		articleResponse.IsPublished.Should().Be(isPublished);
		articleResponse.ModifiedOn.Should().Be(modifiedOn);
		articleResponse.UserName.Should().Be(userName);
		articleResponse.UserId.Should().Be(userId);
		articleResponse.CanEdit.Should().Be(canEdit);

	}

}