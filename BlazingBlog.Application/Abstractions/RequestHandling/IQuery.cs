// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     IQuery.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application
// =======================================================

namespace BlazingBlog.Application.Abstractions.RequestHandling;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
