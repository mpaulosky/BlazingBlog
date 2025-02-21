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
		const string id = "1";
		const string userName = "testuser";
		const string email = "testuser@example.com";
		const string roles = "Admin";

		// Act
		var userResponse = new UserResponse(id, userName, email, roles);

		// Assert
		userResponse.Id.Should().Be(id);
		userResponse.UserName.Should().Be(userName);
		userResponse.Email.Should().Be(email);
		userResponse.Roles.Should().Be(roles);

	}

}