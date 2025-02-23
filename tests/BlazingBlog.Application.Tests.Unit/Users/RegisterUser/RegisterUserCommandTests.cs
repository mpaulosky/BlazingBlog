// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     RegisterUserCommandTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application.Tests.Unit
// =======================================================

namespace BlazingBlog.Application.Users.RegisterUser;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(RegisterUserCommand))]
public class ResisterUserCommandTests
{

	[Fact]
	public void RegisterUserCommand_ShouldInitializePropertiesCorrectly()
	{

		// Arrange
		var userName = "TestUser";
		var email = "testuser@example.com";
		var password = "TestPassword123";

		// Act
		var command = new RegisterUserCommand { UserName = userName, Email = email, Password = password };

		// Assert
		command.UserName.Should().Be(userName);
		command.Email.Should().Be(email);
		command.Password.Should().Be(password);

	}

}