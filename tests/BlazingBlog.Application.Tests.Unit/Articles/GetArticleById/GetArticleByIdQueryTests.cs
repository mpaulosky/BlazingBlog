// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     GetArticleByIdQueryTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application.Tests.Unit
// =======================================================

namespace BlazingBlog.Application.Articles.GetArticleById;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(GetArticleByIdQuery))]
public class GetArticleByIdQueryTests
{

	[Fact]
	public void GetArticleByIdQuery_ShouldSetId()
	{

		// Arrange
		var query = new GetArticleByIdQuery{ Id = 5 };

		// Assert
		query.Id.Should().Be(5);

	}

	[Fact]
	public void GetArticleByIdQuery_ShouldImplementIQuery()
	{

		// Arrange
		var query = new GetArticleByIdQuery();

		// Act & Assert
		query.Should().BeAssignableTo<IQuery<ArticleResponse?>>();

	}

}