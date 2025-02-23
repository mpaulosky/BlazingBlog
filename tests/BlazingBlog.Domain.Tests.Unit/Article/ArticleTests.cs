// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     ArticleTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Domain.Tests.Unit
// =======================================================

namespace BlazingBlog.Domain.Article;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(Article))]
public class ArticleTests
{

	private static readonly DateTimeOffset TestDate = new DateTimeOffset(2025, 1, 1, 0, 0, 0, TimeSpan.Zero);

	private readonly Faker<Article> _articleGenerator =
			new Faker<Article>()
					.UseSeed(421)
					.RuleFor(x => x.Id, f => f.Random.Int(1, 100))
					.RuleFor(x => x.Title, f => f.WaffleTitle())
					.RuleFor(x => x.Content, f => f.WaffleMarkdown(5))
					.RuleFor(x => x.CreatedOn, TestDate)
					.RuleFor(x => x.IsPublished, f => f.Random.Bool())
					.RuleFor(x => x.CreatedOn, TestDate)
					.RuleFor(x => x.PublishedOn, TestDate)
					.RuleFor(x => x.ModifiedOn, TestDate)
					.RuleFor(x => x.UserId, f => f.Random.Guid().ToString());

	[Fact]
	public void Article_ShouldNotBePublished_WhenIsPublishedIsFalse()
	{

		// Arrange
		var article = _articleGenerator.Generate();
		article.IsPublished = false;
		article.PublishedOn = null;

		// Act & Assert
		article.IsPublished.Should().BeFalse();
		article.PublishedOn.Should().BeNull();

	}


	[Fact]
	public void Article_ShouldHandleEmptyTitle()
	{

		// Arrange
		var article =_articleGenerator.Generate();
		article.Title = string.Empty;

		// Act & Assert
		article.Title.Should().BeEmpty();

	}

	[Fact]
	public void Article_ShouldHandleNullContent()
	{

		// Arrange
		var article = _articleGenerator.Generate();
		article.Content = null;

		// Act & Assert
		article.Content.Should().BeNull();

	}

	[Fact]
	public void Article_ShouldHandleFutureCreatedOnDate()
	{

		// Arrange
		var futureDate = new DateTimeOffset(2030, 1, 1, 0, 0, 0, TimeSpan.Zero);
		var article = _articleGenerator.Generate();
		article.CreatedOn = futureDate;
		article.PublishedOn = futureDate;
		article.ModifiedOn = futureDate;

		// Act & Assert
		article.CreatedOn.Should().Be(futureDate);
		article.PublishedOn.Should().Be(futureDate);
		article.ModifiedOn.Should().Be(futureDate);

	}

	[Fact]
	public void Article_ShouldHandleNullUserId()
	{

		// Arrange
		var article =_articleGenerator.Generate();
		article.UserId = null;

		// Act & Assert
		article.UserId.Should().BeNull();

	}

}