// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     GetArticleByIdQuery.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application
// =======================================================

namespace BlazingBlog.Application.Articles.GetArticleById;

public class GetArticleByIdQuery : IQuery<ArticleResponse?>
{

	public int Id { get; set; }

}
