// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     GlobalUsings.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application.Tests.Unit
// =======================================================

global using System.Diagnostics.CodeAnalysis;

global using BlazingBlog.Application.Abstractions.RequestHandling;
global using BlazingBlog.Application.Articles;
global using BlazingBlog.Application.Articles.GetArticlesByCurrentUser;
global using BlazingBlog.Application.Articles.TogglePublishArticle;
global using BlazingBlog.Application.Authentication;
global using BlazingBlog.Application.Exceptions;
global using BlazingBlog.Application.Users;
global using BlazingBlog.Domain.Abstractions;
global using BlazingBlog.Domain.Article;
global using BlazingBlog.Domain.Users;
global using BlazingBlog.Infrastructure.Users;
global using static BlazingBlog.Application.Helpers.Helpers;

global using Bogus;

global using FluentAssertions;

global using JetBrains.Annotations;

global using Mapster;

global using MediatR;

global using Microsoft.Extensions.DependencyInjection;

global using NSubstitute;
global using NSubstitute.ExceptionExtensions;