// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     Entity.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Domain
// =======================================================

namespace BlazingBlog.Domain.Abstractions;

public abstract class Entity
{

	public required int Id { get; set; }

	public DateTimeOffset CreatedOn { get; set; } = DateTime.Now;

	public DateTimeOffset? ModifiedOn { get; set; }

}