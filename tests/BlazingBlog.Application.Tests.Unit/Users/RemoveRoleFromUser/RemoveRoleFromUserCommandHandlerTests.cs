// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     RemoveRoleFromUserCommandHandlerTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application.Tests.Unit
// =======================================================

namespace BlazingBlog.Application.Users.RemoveRoleFromUser;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(RemoveRoleFromUserCommandHandler))]
public class RemoveRoleFromUserCommandHandlerTests
{

	[Fact]
	public async Task METHOD_ShouldReturnSuccess_WhenRoleIsRemovedSuccessfully()
	{

		// Arrange
		var userService = Substitute.For<IUserService>();
		var handler = new RemoveRoleFromUserCommandHandler(userService);
		var command = new RemoveRoleFromUserCommand { UserId = "test-user-id", RoleName = "test-role" };

		userService.RemoveRoleFromUserAsync(command.UserId, command.RoleName)
				.Returns(Task.CompletedTask);

		// Act
		var result = await handler.Handle(command, CancellationToken.None);

		// Assert
		result.Success.Should().BeTrue();
		await userService.Received(1).RemoveRoleFromUserAsync(command.UserId, command.RoleName);

	}

	[Fact]
	public async Task METHOD_ShouldReturnFailure_WhenExceptionIsThrown()
	{

		// Arrange
		var userService = Substitute.For<IUserService>();
		var handler = new RemoveRoleFromUserCommandHandler(userService);
		var command = new RemoveRoleFromUserCommand { UserId = "test-user-id", RoleName = "test-role" };
		var exceptionMessage = "Error occurred";

		userService.RemoveRoleFromUserAsync(command.UserId, command.RoleName)
				.Throws(new Exception(exceptionMessage));

		// Act
		var result = await handler.Handle(command, CancellationToken.None);

		// Assert
		result.Failure.Should().BeTrue();
		result.Error.Should().Be(exceptionMessage);
		await userService.Received(1).RemoveRoleFromUserAsync(command.UserId, command.RoleName);

	}

}