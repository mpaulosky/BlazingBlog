// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     UserResponseTest.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application.Tests.Unit
// =======================================================

namespace BlazingBlog.Application.Users;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(UserResponse))]
public class UserResponseTest
{

	[Fact]
	public void UserResponse_ShouldHaveCorrectProperties()
	{

		// Arrange
		// const string id = "1";
		// const string userName = "test_user";
		// const string email = "testuser@example.com";
		// const string roles = "Admin";

		// Act
		
		var userResponse = new UserResponse("1", "userName", "email", "roles");

		// Assert
		userResponse.Id.Should().Be("1");
		userResponse.UserName.Should().Be("userName");
		userResponse.Email.Should().Be("email");
		userResponse.Roles.Should().Be("roles");

	}

	[Fact]
	public void UserResponse_SetProperties_ShouldUpdateValues()
	{
		// Arrange
		var userResponse = new UserResponse("1", "test-user", "testuser@example.com", "Admin");

		// Act
		userResponse.Id = "2";
		userResponse.UserName = "updated-user";
		userResponse.Email = "updateduser@example.com";
		userResponse.Roles = "User";

		// Assert
		Assert.Equal("2", userResponse.Id);
		Assert.Equal("updated-user", userResponse.UserName);
		Assert.Equal("updateduser@example.com", userResponse.Email);
		Assert.Equal("User", userResponse.Roles);
	}

	[Fact]
	public void UserResponse_ShouldInitializeProperties()
	{

		// Arrange
		const string id = "1";
		const string userName = "test-user";
		const string email = "testuser@example.com";
		const string roles = "Admin";

		// Act
		var userResponse = new UserResponse(id, userName, email, roles);

		// Assert
		Assert.Equal(id, userResponse.Id);
		Assert.Equal(userName, userResponse.UserName);
		Assert.Equal(email, userResponse.Email);
		Assert.Equal(roles, userResponse.Roles);

	}

	[Fact]
	public void UserResponse_ShouldBeEqual_WhenPropertiesAreSame()
	{

		// Arrange
		const string id = "1";
		const string userName = "test-user";
		const string email = "testuser@example.com";
		const string roles = "Admin";

		var userResponse1 = new UserResponse(id, userName, email, roles);
		var userResponse2 = new UserResponse(id, userName, email, roles);

		// Act & Assert
		userResponse1.Should().BeEquivalentTo(userResponse2);

	}

	[Fact]
	public void UserResponse_ShouldNotBeEqual_WhenPropertiesAreDifferent()
	{

		// Arrange
		var userResponse1 = new UserResponse("1", "test-user1", "testuser1@example.com", "Admin");
		var userResponse2 = new UserResponse("2", "test-user2", "testuser2@example.com", "User");

		// Act & Assert
		userResponse1.Should().NotBeEquivalentTo(userResponse2);

	}

}