// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     AddRoleToUserCommandHandlerTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application.Tests.Unit
// =======================================================

namespace BlazingBlog.Application.Users.AddRoleToUser;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(AddRoleToUserCommandHandler))]
public class AddRoleToUserCommandHandlerTests
{

	[Fact]
	public async Task Handle_ShouldReturnOkResult_WhenRoleIsAddedSuccessfully()
	{

		// Arrange
		var userService = Substitute.For<IUserService>();
		userService.AddRoleToUserAsync(Arg.Any<string>(), Arg.Any<string>()).Returns(Task.CompletedTask);
		var handler = new AddRoleToUserCommandHandler(userService);
		var command = new AddRoleToUserCommand { UserId = "test-user-id", RoleName = "test-role" };

		// Act
		var result = await handler.Handle(command, CancellationToken.None);

		// Assert
		result.Success.Should().BeTrue();
		await userService.Received(1).AddRoleToUserAsync(command.UserId, command.RoleName);

	}

	[Fact]
	public async Task Handle_ShouldReturnFailResult_WhenExceptionIsThrown()
	{

		// Arrange
		var userService = Substitute.For<IUserService>();
		userService.AddRoleToUserAsync(Arg.Any<string>(), Arg.Any<string>()).Throws(new Exception("Error"));
		var handler = new AddRoleToUserCommandHandler(userService);
		var command = new AddRoleToUserCommand { UserId = "test-user-id", RoleName = "test-role" };

		// Act
		var result = await handler.Handle(command, CancellationToken.None);

		// Assert
		result.Success.Should().BeFalse();
		result.Error.Should().Contain("Error");
		await userService.Received(1).AddRoleToUserAsync(command.UserId, command.RoleName);

	}

}