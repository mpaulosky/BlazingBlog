// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     RemoveRoleFromUserCommandTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application.Tests.Unit
// =======================================================

namespace BlazingBlog.Application.Users.RemoveRoleFromUser;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(RemoveRoleFromUserCommand))]
public class RemoveRoleFromUserCommandTests
{

	[Fact]
	public async Task Should_Return_Success_When_Role_Is_Removed_From_User()
	{

		// Arrange
		var userId = "test-user-id";
		var roleName = "TestRole";
		var command = new RemoveRoleFromUserCommand { UserId = userId, RoleName = roleName };
		var handler = Substitute.For<IRequestHandler<RemoveRoleFromUserCommand, Result>>();
		handler.Handle(command, CancellationToken.None).Returns(Result.Ok());

		// Act
		var result = await handler.Handle(command, CancellationToken.None);

		// Assert
		result.Success.Should().BeTrue();
		result.Failure.Should().BeFalse();
		result.Error.Should().BeNull();

	}

	[Fact]
	public void Should_Return_Failure_When_Handler_Throws_Exception()
	{

		// Arrange
		var userId = "test-user-id";
		var roleName = "TestRole";
		var command = new RemoveRoleFromUserCommand { UserId = userId, RoleName = roleName };
		var handler = Substitute.For<IRequestHandler<RemoveRoleFromUserCommand, Result>>();
		handler.Handle(command, CancellationToken.None).Throws(new Exception("Test Exception"));

		// Act
		var exception = Record.Exception(() => handler.Handle(command, CancellationToken.None).Result);

		// Assert
		exception.Should().NotBeNull();
		exception.Message.Should().Be("Test Exception");

	}

}