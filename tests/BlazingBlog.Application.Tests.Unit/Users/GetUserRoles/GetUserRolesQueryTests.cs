// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     GetUserRolesQueryTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application.Tests.Unit
// =======================================================

namespace BlazingBlog.Application.Users.GetUserRoles;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(GetUserRolesQuery))]
public class GetUserRolesQueryTests
{

	[Fact]
	public void GetUserRolesQuery_ShouldHaveRequiredProperties()
	{

		// Arrange
		var query = new GetUserRolesQuery { UserId = string.Empty };

		// Act & Assert
		query.UserId.Should().BeEmpty();

	}

	[Fact]
	public void GetUserRolesQuery_ShouldSetPropertiesCorrectly()
	{

		// Arrange
		var userId = "test-user-id";
		var query = new GetUserRolesQuery { UserId = userId };

		// Act & Assert
		query.UserId.Should().Be(userId);

	}

}