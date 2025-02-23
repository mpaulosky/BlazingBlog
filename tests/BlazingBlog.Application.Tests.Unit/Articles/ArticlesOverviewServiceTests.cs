// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     ArticlesOverviewServiceTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application.Tests.Unit
// =======================================================

namespace BlazingBlog.Application.Articles;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(ArticlesOverviewService))]
public class ArticlesOverviewServiceTests
{

	private static readonly DateTimeOffset TestDate = new DateTimeOffset(2025, 1, 1, 0, 0, 0, TimeSpan.Zero);

	[Fact]
	public async Task TogglePublishArticleAsync_Should_Return_ArticleResponse_When_Successful()
	{

		// Arrange
		var sender = Substitute.For<ISender>();
		var articleId = 1;

		var articleResponse = new ArticleResponse
		(
			articleId,
			"Article Title",
			"Content",
			TestDate,
			TestDate,
			TestDate,
			true,
			"UserName",
			"UserId",
			true
		);

		sender.Send(Arg.Any<TogglePublishArticleCommand>())
				.Returns(articleResponse);

		var service = new ArticlesOverviewService(sender);

		// Act
		var result = await service.TogglePublishArticleAsync(articleId);

		// Assert
		result.Should().BeEquivalentTo(articleResponse);
		await sender.Received(1).Send(Arg.Is<TogglePublishArticleCommand>(cmd => cmd.ArticleId == articleId));

	}

	[Fact]
	public async Task GetArticlesByCurrentUserAsync_Should_Return_ListOfArticleResponses_When_Successful()
	{

		// Arrange
		var sender = Substitute.For<ISender>();

		var articleResponses = new List<ArticleResponse>
		{
				new(
						1,
						"Article Title",
						"Content",
						TestDate,
						TestDate,
						TestDate,
						true,
						"UserName",
						"UserId",
						true
				),
				new(
						2,
						"Article Title",
						"Content",
						TestDate,
						TestDate,
						TestDate,
						true,
						"UserName",
						"UserId",
						true
				)
		};

		sender.Send(Arg.Any<GetArticlesByCurrentUserQuery>())
				.Returns(articleResponses);

		var service = new ArticlesOverviewService(sender);

		// Act
		var result = await service.GetArticlesByCurrentUserAsync();

		// Assert
		result.Should().BeEquivalentTo(articleResponses);
		await sender.Received(1).Send(Arg.Any<GetArticlesByCurrentUserQuery>());

	}

}