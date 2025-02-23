// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     RegisterUserResponseTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application.Tests.Unit
// =======================================================

namespace BlazingBlog.Application.Authentication;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(RegisterUserResponse))]
public class RegisterUserResponseTests
{

	[Fact]
	public void RegisterUserResponse_ShouldHaveDefaultValues()
	{

		// Arrange
		var response = new RegisterUserResponse();

		// Act & Assert
		response.Succeeded.Should().BeFalse();
		response.Errors.Should().BeEmpty();

	}

	[Fact]
	public void RegisterUserResponse_ShouldAllowSettingSucceeded()
	{

		// Arrange
		var response = new RegisterUserResponse();

		// Act
		response.Succeeded = true;

		// Assert
		response.Succeeded.Should().BeTrue();

	}

	[Fact]
	public void RegisterUserResponse_ShouldAllowAddingErrors()
	{

		// Arrange
		var response = new RegisterUserResponse();
		var error = "An error occurred";

		// Act
		response.Errors.Add(error);

		// Assert
		response.Errors.Should().ContainSingle().Which.Should().Be(error);

	}

}