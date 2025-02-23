// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     AddRoleToUserCommandTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application.Tests.Unit
// =======================================================

namespace BlazingBlog.Application.Users.AddRoleToUser;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(AddRoleToUserCommand))]
public class AddRoleToUserCommandTests
{

	[Fact]
	public void AddRoleToUserCommand_ShouldHaveRequiredProperties()
	{

		// Arrange
		var command = new AddRoleToUserCommand
		{
				UserId = string.Empty,
				RoleName = string.Empty
		};
	
		// Act & Assert
		command.UserId.Should().BeEmpty();
		command.RoleName.Should().BeEmpty();

	}
	
	[Fact]
	public void AddRoleToUserCommand_ShouldSetPropertiesCorrectly()
	{

		// Arrange
		var userId = "test-user-id";
		var roleName = "test-role";
		var command = new AddRoleToUserCommand
		{
			UserId = userId,
			RoleName = roleName
		};
	
		// Act & Assert
		command.UserId.Should().Be(userId);
		command.RoleName.Should().Be(roleName);

	}

}