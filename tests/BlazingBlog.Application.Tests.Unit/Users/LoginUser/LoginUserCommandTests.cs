// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     LoginUserCommandTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application.Tests.Unit
// =======================================================

namespace BlazingBlog.Application.Users.LoginUser;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(LoginUserCommand))]
public class LoginUserCommandTests
{

	[Fact]
	public void Constructor_Should_CreateInstance_WithRequiredProperties()
	{

		// Arrange
		var userName = "test-user";
		var password = "p@ssword";

		// Act
		var command = new LoginUserCommand { UserName = userName, Password = password };

		// Assert
		command.UserName.Should().Be(userName);
		command.Password.Should().Be(password);

	}

}