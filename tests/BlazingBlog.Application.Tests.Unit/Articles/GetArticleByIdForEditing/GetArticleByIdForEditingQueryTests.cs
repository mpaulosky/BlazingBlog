// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     GetArticleByIdForEditingQueryTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application.Tests.Unit
// =======================================================

namespace BlazingBlog.Application.Articles.GetArticleByIdForEditing;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(GetArticleByIdForEditingQuery))]
public class GetArticleByIdForEditingQueryTests
{

	[Fact]
	public void GetArticleByIdForEditingQuery_ShouldSetId()
	{

		// Arrange
		var query = new GetArticleByIdForEditingQuery();

		// Act
		query.Id = 5;

		// Assert
		query.Id.Should().Be(5);

	}

	[Fact]
	public void GetArticleByIdForEditingQuery_ShouldImplementIQuery()
	{

		// Arrange
		var query = new GetArticleByIdForEditingQuery();

		// Act & Assert
		query.Should().BeAssignableTo<IQuery<ArticleResponse?>>();

	}

}