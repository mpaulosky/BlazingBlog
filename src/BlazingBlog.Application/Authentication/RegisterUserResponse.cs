// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     RegisterUserResponse.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application
// =======================================================

namespace BlazingBlog.Application.Authentication;

public class RegisterUserResponse
{

	public bool Succeeded { get; set; }

	public List<string> Errors { get; set; } = [];

}
