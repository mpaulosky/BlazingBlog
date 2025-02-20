// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     GlobalUsings.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application
// =======================================================

global using System;
global using System.Collections.Generic;
global using System.Threading;
global using System.Threading.Tasks;

global using BlazingBlog.Application.Abstractions.RequestHandling;
global using BlazingBlog.Application.Articles.GetArticlesByCurrentUser;
global using BlazingBlog.Application.Articles.TogglePublishArticle;
global using BlazingBlog.Application.Authentication;
global using BlazingBlog.Application.Exceptions;
global using BlazingBlog.Application.Users;
global using BlazingBlog.Domain.Abstractions;
global using BlazingBlog.Domain.Article;
global using BlazingBlog.Domain.Users;

global using Mapster;

global using MediatR;

global using Microsoft.Extensions.DependencyInjection;
