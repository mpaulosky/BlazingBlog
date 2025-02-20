// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     ArticlesTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Domain.Tests.Unit
// =======================================================

// ReSharper disable once CheckNamespace
namespace BlazingBlog.Domain.Article;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(Article))]
public class ArticlesTests
{

	private static readonly DateTimeOffset TestDate = new DateTimeOffset(2025, 1, 1, 0, 0, 0, TimeSpan.Zero);

	private readonly Faker<Article> _articleGenerator = new Faker<Article>()
			.UseSeed(421)
			.RuleFor(x => x.Id, f => f.Random.Int())
			.RuleFor(x => x.Title, f => f.WaffleTitle())
			.RuleFor(x => x.Content, f => f.WaffleMarkdown(paragraphs:4, includeHeading:true))
			.RuleFor(x => x.CreatedOn, TestDate)
			.RuleFor(x => x.IsPublished, true)
			.RuleFor(x => x.PublishedOn, TestDate)
			.RuleFor(x => x.UserId, f => f.Random.Guid().ToString());

	[Fact]
	public void Article_ShouldHaveExpectedValues_WhenGeneratedWithFaker()
	{

		// Arrange
		var testArticle = _articleGenerator.Generate();
	
		// Act
		var article = new Article
		{
			Id = testArticle.Id,
			Title = testArticle.Title,
			Content = testArticle.Content,
			CreatedOn = testArticle.CreatedOn,
			IsPublished = testArticle.IsPublished,
			PublishedOn = testArticle.PublishedOn,
			UserId = testArticle.UserId
		};
	
		// Assert
		article.Id.Should().Be(testArticle.Id);
		article.Title.Should().Be(testArticle.Title);
		article.Content.Should().Be(testArticle.Content);
		article.CreatedOn.Should().Be(testArticle.CreatedOn);
		article.IsPublished.Should().Be(testArticle.IsPublished);
		article.PublishedOn.Should().Be(testArticle.PublishedOn);
		article.PublishedOn.Should().Be(testArticle.CreatedOn);
		article.UserId.Should().Be(testArticle.UserId);

	}
	
	[Fact]
	public void Article_ShouldSetAndGetPropertiesCorrectly()
	{

		// Arrange
		var article = new Article
		{
				Id = 1,
				Title = "Test Title",
				Content = "Test Content",
				CreatedOn = TestDate,
				IsPublished = true,
				PublishedOn = TestDate,
				UserId = "test-user-id"
		};

		// Act

		// Assert
		article.Id.Should().Be(1);
		article.Title.Should().Be("Test Title");
		article.Content.Should().Be("Test Content");
		article.CreatedOn.Should().Be(TestDate);
		article.IsPublished.Should().BeTrue();
		article.PublishedOn.Should().Be(TestDate);
		article.UserId.Should().Be("test-user-id");

	}

	[Fact]
	public void Article_ShouldHandleNullPublishedOn()
	{
		// Arrange
		var article = new Article
		{
				Id = 1,
				Title = "Test Title",
				Content = "Test Content",
				CreatedOn = TestDate,
				IsPublished = true,
				PublishedOn = null,
				UserId = "test-user-id"
		};

		// Act
		article.PublishedOn = null;

		// Assert
		article.PublishedOn.Should().BeNull();
	}

}