// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     RegisterUserCommandHandlerTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application.Tests.Unit
// =======================================================

namespace BlazingBlog.Application.Users.RegisterUser;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(RegisterUserCommandHandler))]
public class RegisterUserCommandHandlerTests
{

	[Fact]
	public async Task METHOD_Should_ReturnSuccessResult_When_RegistrationSucceeds()
	{

		// Arrange
		var authenticationService = Substitute.For<IAuthenticationService>();

		var command = new RegisterUserCommand
		{
				UserName = "test-user", Email = "testuser@example.com", Password = "Test@123"
		};

		var response = new RegisterUserResponse { Succeeded = true };

		authenticationService.RegisterUserAsync(command.UserName, command.Email, command.Password)
				.Returns(Task.FromResult(response));

		var handler = new RegisterUserCommandHandler(authenticationService);

		// Act
		var result = await handler.Handle(command, CancellationToken.None);

		// Assert
		result.Success.Should().BeTrue();
		result.Failure.Should().BeFalse();
		await authenticationService.Received(1).RegisterUserAsync(command.UserName, command.Email, command.Password);

	}

	[Fact]
	public async Task METHOD_Should_ReturnFailureResult_When_RegistrationFails()
	{

		// Arrange
		var authenticationService = Substitute.For<IAuthenticationService>();

		var command = new RegisterUserCommand
		{
				UserName = "test-user", Email = "testuser@example.com", Password = "Test@123"
		};

		var response = new RegisterUserResponse { Succeeded = false, Errors = ["Error 1", "Error 2"] };

		authenticationService.RegisterUserAsync(command.UserName, command.Email, command.Password)
				.Returns(Task.FromResult(response));

		var handler = new RegisterUserCommandHandler(authenticationService);

		// Act
		var result = await handler.Handle(command, CancellationToken.None);

		// Assert
		result.Success.Should().BeFalse();
		result.Failure.Should().BeTrue();
		result.Error.Should().Be("Error 1, Error 2");
		await authenticationService.Received(1).RegisterUserAsync(command.UserName, command.Email, command.Password);

	}

}