// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     EntityTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Domain.Tests.Unit
// =======================================================

namespace BlazingBlog.Domain.Abstractions;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(Entity))]
public class EntityTests
{

	[Fact]
	public void Entity_ShouldInitializeWithDefaultValues()
	{

		// Arrange
		var entity = new TestEntity
		{
				Id = 0
		};

		// Act & Assert
		Assert.Equal(0, entity.Id);
		Assert.Equal(DateTime.Now.Date, entity.CreatedOn.Date);
		Assert.Null(entity.ModifiedOn);

	}

	[Fact]
	public void Entity_ShouldAllowSettingProperties()
	{

		// Arrange
		var entity = new TestEntity
		{
				Id = 1,
				CreatedOn = new DateTimeOffset(new DateTime(2025, 1, 1)),
				ModifiedOn = new DateTimeOffset(new DateTime(2025, 1, 2))
		};

		// Act & Assert
		Assert.Equal(1, entity.Id);
		Assert.Equal(new DateTimeOffset(new DateTime(2025, 1, 1)), entity.CreatedOn);
		Assert.Equal(new DateTimeOffset(new DateTime(2025, 1, 2)), entity.ModifiedOn);

	}

	private class TestEntity : Entity
	{
	}

}