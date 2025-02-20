// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     UserResponse.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application
// =======================================================

namespace BlazingBlog.Application.Users;

public record struct UserResponse
(
		string Id,
		string UserName,
		string Email,
		string Roles
);
