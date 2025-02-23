// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     GetUsersQueryHandlerTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application.Tests.Unit
// =======================================================

namespace BlazingBlog.Application.Users.GetUsers;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(GetUsersQueryHandler))]
public class GetUsersQueryHandlerTests
{

	[Fact]
	public async Task Handle_ShouldReturnAllUsers_WhenUserIsAdmin()
	{

		// Arrange
		var userRepository = Substitute.For<IUserRepository>();
		var userService = Substitute.For<IUserService>();
		var handler = new GetUsersQueryHandler(userRepository, userService);
		var query = new GetUsersQuery();
		var cancellationToken = CancellationToken.None;

		userService.IsCurrentUserInRoleAsync("Admin").Returns(true);
		var users = new List<User> { new User { Id = "1", UserName = "Test User" } };
		userRepository.GetAllUsersAsync().Returns(users.Cast<IUser>().ToList());
		userService.GetUserRolesAsync("1").Returns(Task.FromResult(new List<string> { "Admin" }));

		// Act
		var result = await handler.Handle(query, cancellationToken);

		// Assert
		result.Success.Should().BeTrue();
		result.Value.Should().HaveCount(1);
		result.Value!.First().UserName.Should().Be("Test User");
		result.Value!.First().Roles.Should().Be("Admin");

	}

	[Fact]
	public async Task Handle_ShouldReturnFailure_WhenUserIsNotAdmin()
	{

		// Arrange
		var userRepository = Substitute.For<IUserRepository>();
		var userService = Substitute.For<IUserService>();
		var handler = new GetUsersQueryHandler(userRepository, userService);
		var query = new GetUsersQuery();
		var cancellationToken = CancellationToken.None;

		userService.IsCurrentUserInRoleAsync("Admin").Returns(false);

		// Act
		var result = await handler.Handle(query, cancellationToken);

		// Assert
		result.Success.Should().BeFalse();
		result.Error.Should().Be("You're not allowed to see all users.");

	}

}