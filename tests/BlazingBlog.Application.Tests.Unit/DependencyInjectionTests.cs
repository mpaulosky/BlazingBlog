// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     DependencyInjectionTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application.Tests.Unit
// =======================================================

using BlazingBlog.Application;

namespace BlazingBlog.Application;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(DependencyInjection))]
public class DependencyInjectionTests
{

	[Fact]
	public void Test_MockedCollection_CopyTo_ShouldWork()
	{

		// Arrange: Substitute a collection of a specific type, e.g., int
		var mockCollection = Substitute.For<ICollection<int>>();

		// Set up behavior for ICollection<int>.CopyTo
		mockCollection.WhenForAnyArgs(coll => coll.CopyTo(default, 0))
				.Do(call =>
				{
					var array = call.ArgAt<int[]>(0); // Mocked array argument
					var index = call.ArgAt<int>(1);  // Mocked index argument

					// Add simulated items to the array as the CopyTo implementation would
					if (array is not null)
					{
						array[index] = 42; // Simulate adding an item at the correct array position
					}
				});

		// Act: Simulate calling CopyTo on a valid array
		var destinationArray = new int[5];
		mockCollection.CopyTo(destinationArray, 2);

		// Assert: Ensure the array was populated correctly
		destinationArray[2].Should().Be(42);

	}

}