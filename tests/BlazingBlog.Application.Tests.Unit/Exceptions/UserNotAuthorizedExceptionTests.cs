// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     UserNotAuthorizedExceptionTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application.Tests.Unit
// =======================================================

namespace BlazingBlog.Application.Exceptions;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(UserNotAuthorizedException))]
public class UserNotAuthorizedExceptionTests
{

	[Fact]
	public void Constructor_Should_Initialize_With_Default_Message()
	{

		// Arrange & Act
		var exception = new UserNotAuthorizedException();

		// Assert
		exception.Message.Should()
				.Be("Exception of type 'BlazingBlog.Application.Exceptions.UserNotAuthorizedException' was thrown.");

	}

	[Fact]
	public void Constructor_With_Message_Should_Set_Message()
	{

		// Arrange
		var message = "User is not authorized.";

		// Act
		var exception = new UserNotAuthorizedException(message);

		// Assert
		exception.Message.Should().Be(message);

	}

	[Fact]
	public void Constructor_With_Message_And_InnerException_Should_Set_Properties()
	{

		// Arrange
		var message = "User is not authorized.";
		var innerException = new Exception("Inner exception message.");

		// Act
		var exception = new UserNotAuthorizedException(message, innerException);

		// Assert
		exception.Message.Should().Be(message);
		exception.InnerException.Should().Be(innerException);

	}

}