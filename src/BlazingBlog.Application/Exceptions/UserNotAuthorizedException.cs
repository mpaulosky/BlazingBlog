// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     UserNotAuthorizedException.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application
// =======================================================

namespace BlazingBlog.Application.Exceptions;

public class UserNotAuthorizedException : Exception
{

	public UserNotAuthorizedException() : base() { }

	public UserNotAuthorizedException(string message) : base(message) { }

	public UserNotAuthorizedException(
			string message,
			Exception innerException) : base(message, innerException) { }

}
