// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     Helpers.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application.Tests.Unit
// =======================================================

namespace BlazingBlog.Application.Helpers;

[ExcludeFromCodeCoverage]
public static class Helpers
{

	internal static DateTimeOffset TestDate = new DateTimeOffset(2025, 1, 1, 0, 0, 0, TimeSpan.Zero);

	public static readonly Faker<Article> ArticleGenerator =
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

	public static readonly Faker<User> UserGenerator = new Faker<User>()
			.UseSeed(421)
			.RuleFor(x => x.Id, f => f.Random.Guid().ToString())
			.RuleFor(x => x.UserName, f => f.Internet.UserName())
			.RuleFor(x => x.Email, f => f.Internet.Email());

}