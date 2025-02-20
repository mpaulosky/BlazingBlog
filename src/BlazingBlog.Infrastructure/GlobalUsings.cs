// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     GlobalUsings.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Infrastructure
// =======================================================

global using System;
global using System.Collections.Generic;
global using System.Threading.Tasks;

global using BlazingBlog.Application.Articles;
global using BlazingBlog.Application.Authentication;
global using BlazingBlog.Application.Exceptions;
global using BlazingBlog.Application.Users;
global using BlazingBlog.Domain.Article;
global using BlazingBlog.Domain.Users;
global using BlazingBlog.Infrastructure.Articles;
global using BlazingBlog.Infrastructure.Authentication;
global using BlazingBlog.Infrastructure.Repositories;
global using BlazingBlog.Infrastructure.Users;

global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Authorization.Policy;
global using Microsoft.AspNetCore.Components.Authorization;
global using Microsoft.AspNetCore.Components.Server;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;