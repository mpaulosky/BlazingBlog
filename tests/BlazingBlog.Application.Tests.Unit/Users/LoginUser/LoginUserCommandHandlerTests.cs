// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     LoginUserCommandHandlerTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application.Tests.Unit
// =======================================================

namespace BlazingBlog.Application.Users.LoginUser;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(LoginUserCommandHandler))]
public class LoginUserCommandHandlerTests
{

	[Fact]
	public async Task Handle_ShouldReturnOkResult_WhenAuthenticationSucceeds()
	{

		// Arrange
		var authenticationService = Substitute.For<IAuthenticationService>();
		var commandHandler = new LoginUserCommandHandler(authenticationService);
		var command = new LoginUserCommand { UserName = "testUser", Password = "testPassword" };
		authenticationService.LoginUserAsync(command.UserName, command.Password).Returns(true);

		// Act
		var result = await commandHandler.Handle(command, CancellationToken.None);

		// Assert
		result.Success.Should().BeTrue();
		result.Failure.Should().BeFalse();
		result.Error.Should().BeNullOrEmpty();

	}

	[Fact]
	public async Task Handle_ShouldReturnFailResult_WhenAuthenticationFails()
	{

		// Arrange
		var authenticationService = Substitute.For<IAuthenticationService>();
		var commandHandler = new LoginUserCommandHandler(authenticationService);
		var command = new LoginUserCommand { UserName = "testUser", Password = "wrongPassword" };
		authenticationService.LoginUserAsync(command.UserName, command.Password).Returns(false);

		// Act
		var result = await commandHandler.Handle(command, CancellationToken.None);

		// Assert
		result.Success.Should().BeFalse();
		result.Failure.Should().BeTrue();
		result.Error.Should().Be("Invalid username or password");

	}

}