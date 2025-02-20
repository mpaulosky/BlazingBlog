// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     ArticlesController.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.WebUI.Server
// =======================================================

using BlazingBlog.Application.Articles;

using Microsoft.AspNetCore.Mvc;

namespace BlazingBlog.Web.Server.Components.Features.Articles.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArticlesController : Controller
{

	private readonly IArticlesOverviewService _articlesOverviewService;

	public ArticlesController(IArticlesOverviewService articlesOverviewService)
	{

		_articlesOverviewService = articlesOverviewService;

	}

	[HttpGet]
	public async Task<ActionResult<List<ArticleResponse>>> GetArticlesByCurrentUser()
	{

		var result = await _articlesOverviewService.GetArticlesByCurrentUserAsync();

		return Ok(result);

	}

	[HttpPatch("{id}")]
	public async Task<ActionResult<ArticleResponse>> TogglePublishArticle(int id)
	{

		var result = await _articlesOverviewService.TogglePublishArticleAsync(id);

		if (result is null)
		{

			return BadRequest();

		}

		return Ok(result);

	}

}