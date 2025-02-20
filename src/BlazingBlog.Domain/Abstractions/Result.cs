// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     Result.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Domain
// =======================================================

namespace BlazingBlog.Domain.Abstractions;

public class Result
{

	public bool Success { get; }

	public bool Failure => !Success;

	public string? Error { get; }

	public Result(bool success, string? errorMessage = null)
	{

		Success = success;

		Error = errorMessage;

	}

	public static Result Ok() => new (true);

	public static Result Fail(string errorMessage) => new (false, errorMessage);

	public static Result<T> Ok<T>(T value) => new (value, true, string.Empty);

	public static Result<T> Fail<T>(string errorMessage) => new (default, false, errorMessage);

	public static Result<T> FromValue<T>(T? value) => value != null ? Ok(value) : Fail<T>("Provided value is null.");

}

public class Result<T> : Result
{

	public T? Value { get; }

	protected internal Result(T? value, bool success, string errorMessage) : base(success, errorMessage)
	{

		Value = value;

	}

	public static implicit operator Result<T>(T value) => FromValue(value);

	public static implicit operator T?(Result<T> result) => result.Value;

}
