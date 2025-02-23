// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     ArticleResponse.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application
// =======================================================

namespace BlazingBlog.Application.Articles;

public record struct ArticleResponse
(
		int Id,
		string Title,
		string? Content,
		DateTimeOffset CreatedOn,
		DateTimeOffset? PublishedOn,
		DateTimeOffset? ModifiedOn,
		bool IsPublished,
		string UserName,
		string UserId,
		bool CanEdit
);