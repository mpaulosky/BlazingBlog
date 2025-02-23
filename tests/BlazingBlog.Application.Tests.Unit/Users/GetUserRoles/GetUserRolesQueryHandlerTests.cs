// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     GetUserRolesQueryHandlerTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application.Tests.Unit
// =======================================================

namespace BlazingBlog.Application.Users.GetUserRoles;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(GetUserRolesQueryHandler))]
public class GetUserRolesQueryHandlerTests
{

	[Fact]
	public async Task Handle_ShouldReturnUserRoles_WhenUserIdIsValid()
	{

		// Arrange
		var userService = Substitute.For<IUserService>();
		var handler = new GetUserRolesQueryHandler(userService);
		var query = new GetUserRolesQuery { UserId = "valid-user-id" };
		var expectedRoles = new List<string> { "Admin", "User" };
		userService.GetUserRolesAsync(query.UserId).Returns(expectedRoles);

		// Act
		var result = await handler.Handle(query, CancellationToken.None);

		// Assert
		result.Success.Should().BeTrue();
		result.Value.Should().BeEquivalentTo(expectedRoles);

	}

	[Fact]
	public async Task Handle_ShouldReturnEmptyList_WhenUserHasNoRoles()
	{

		// Arrange
		var userService = Substitute.For<IUserService>();
		var handler = new GetUserRolesQueryHandler(userService);
		var query = new GetUserRolesQuery { UserId = "user-without-roles" };
		var expectedRoles = new List<string>();
		userService.GetUserRolesAsync(query.UserId).Returns(expectedRoles);

		// Act
		var result = await handler.Handle(query, CancellationToken.None);

		// Assert
		result.Success.Should().BeTrue();
		result.Value.Should().BeEmpty();

	}

}