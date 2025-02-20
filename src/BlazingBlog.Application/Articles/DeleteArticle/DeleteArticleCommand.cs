// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     DeleteArticleCommand.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application
// =======================================================

namespace BlazingBlog.Application.Articles.DeleteArticle;

public class DeleteArticleCommand : ICommand
{

	public int Id { get; set; }

}
