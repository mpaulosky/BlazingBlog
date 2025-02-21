// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     ResultTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Domain.Tests.Unit
// =======================================================

namespace BlazingBlog.Domain.Abstractions;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(Result))]
public class ResultTests
{

	[Fact]
    public void Result_Ok_ShouldReturnSuccessResult()
    {
        // Act
        var result = Result.Ok();

        // Assert
        result.Success.Should().BeTrue();
        result.Error.Should().BeNull();
    }

    [Fact]
    public void Result_Fail_ShouldReturnFailureResult()
    {
        // Arrange
        var errorMessage = "Error occurred";

        // Act
        var result = Result.Fail(errorMessage);

        // Assert
        result.Success.Should().BeFalse();
        result.Error.Should().Be(errorMessage);
    }

    [Fact]
    public void Result_Generic_Ok_ShouldReturnSuccessResultWithValue()
    {
        // Arrange
        var value = "Test Value";

        // Act
        var result = Result.Ok(value);

        // Assert
        result.Success.Should().BeTrue();
        result.Error.Should().BeEmpty();
        result.Value.Should().Be(value);
    }

    [Fact]
    public void Result_Generic_Fail_ShouldReturnFailureResultWithErrorMessage()
    {
        // Arrange
        var errorMessage = "Error occurred";

        // Act
        var result = Result.Fail<string>(errorMessage);

        // Assert
        result.Success.Should().BeFalse();
        result.Error.Should().Be(errorMessage);
        result.Value.Should().BeNull();
    }

    [Fact]
    public void Result_FromValue_ShouldReturnSuccessResultWhenValueIsNotNull()
    {
        // Arrange
        var value = "Test Value";

        // Act
        var result = Result.FromValue(value);

        // Assert
        result.Success.Should().BeTrue();
        result.Error.Should().BeEmpty();
        result.Value.Should().Be(value);
    }

    [Fact]
    public void Result_FromValue_ShouldReturnFailureResultWhenValueIsNull()
    {
        // Act
        var result = Result.FromValue<string>(null);

        // Assert
        result.Success.Should().BeFalse();
        result.Error.Should().Be("Provided value is null.");
        result.Value.Should().BeNull();
    }

    [Fact]
    public void Result_ImplicitOperator_ShouldReturnResultWithExpectedValue()
    {
        // Arrange
        var expectedValue = "Test Value";

        // Act
        Result<string> result = expectedValue;

        // Assert
        result.Value.Should().Be(expectedValue);
        result.Success.Should().BeTrue();
        result.Error.Should().BeEmpty();
    }

    [Fact]
    public void Result_ImplicitOperator_ShouldReturnValue()
    {
        // Arrange
        var expectedValue = "Test Value";
        var result = new Result<string>(expectedValue, true, string.Empty);

        // Act
        string? value = result;

        // Assert
        value.Should().Be(expectedValue);
    }

	[Fact]
	public void Result_Failure_ShouldReturnOppositeOfSuccess()
	{
		// Arrange
		// var successResult = Result.Ok();
		var failureResult = Result.Fail("Error occurred");

		// Act & Assert
		failureResult.Success.Should().BeFalse();
		failureResult.Failure.Should().BeTrue();
	}

}