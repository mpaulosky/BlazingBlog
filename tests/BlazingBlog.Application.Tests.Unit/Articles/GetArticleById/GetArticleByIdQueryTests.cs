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

	private readonly Faker<User> _userGenerator = new Faker<User>()
		.UseSeed(421)
		.RuleFor(x => x.Id, f => f.Random.Guid().ToString())
		.RuleFor(x => x.UserName, f => f.Internet.UserName())
		.RuleFor(x => x.Email, f => f.Internet.Email());
	
	[Fact]
	public async Task Handle_ShouldReturnArticleResponse_WhenArticleExists()
	{

		// Arrange
		var articleService = Substitute.For<IArticleService>();
		var expectedArticle = _articleGenerator.Generate();
		var query = new GetArticleByIdQuery { Id = expectedArticle.Id };

		articleService.GetArticleByIdAsync(query.Id).Returns(expectedArticle);

		var userRepository = Substitute.For<IUserRepository>();
		var user = _userGenerator.Generate();
		user.Id = expectedArticle!.UserId;
		user.Articles = [expectedArticle];
		
		userRepository.GetUserByIdAsync(expectedArticle!.UserId).Returns(user);
		var userService = Substitute.For<IUserService>();
		var handler = new GetArticleByIdQueryHandler(articleService, userRepository, userService);

		// Act
		var result = (await handler.Handle(query, CancellationToken.None)).Value;

		// Assert
		result.Should().NotBeNull();
		var article = result.Adapt<Article>();
		article.Id.Should().Be(expectedArticle.Id);
		article.Title.Should().Be(expectedArticle.Title);
		article.Content.Should().Be(expectedArticle.Content);
		article.CreatedOn.Should().Be(expectedArticle.CreatedOn);
		article.IsPublished.Should().Be(expectedArticle.IsPublished);
		article.PublishedOn.Should().Be(expectedArticle.PublishedOn);
		article.ModifiedOn.Should().Be(expectedArticle.ModifiedOn);
		article.UserId.Should().Be(expectedArticle.UserId);

	}

	[Fact]
	public async Task Handle_ShouldReturnNull_WhenArticleDoesNotExist()
	{

		// Arrange
		var articleService = Substitute.For<IArticleService>();
		var query = new GetArticleByIdQuery { Id = 10 };

		var userRepository = Substitute.For<IUserRepository>();
		var userService = Substitute.For<IUserService>();
		var handler = new GetArticleByIdQueryHandler(articleService, userRepository, userService);

		// Act
		var result = await handler.Handle(query, CancellationToken.None);

		// Assert
		result.Success.Should().BeFalse();
		result.Failure.Should().BeTrue();
		result.Error.Should().Be("The article does not exist.");
		result.Value.Should().BeNull();

	}

}