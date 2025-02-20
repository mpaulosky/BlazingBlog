// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     ApplicationDbContext.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Infrastructure
// =======================================================

using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlazingBlog.Infrastructure;

public class ApplicationDbContext : IdentityDbContext<User>
{

	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

	public DbSet<Article> Articles { get; set; }


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{

		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<User>()
				.HasIndex(p => p.Id)
				.IsUnique();

		modelBuilder.Entity<Article>()
				.HasIndex(p => p.Id)
				.IsUnique();

		modelBuilder
				.Entity<Article>()
				.Property(e => e.CreatedOn)
				.HasConversion(new DateTimeOffsetConverter());


		modelBuilder
				.Entity<Article>()
				.Property(e => e.PublishedOn)
				.HasConversion(new DateTimeOffsetConverter());

		modelBuilder
				.Entity<Article>()
				.Property(e => e.ModifiedOn)
				.HasConversion(new DateTimeOffsetConverter());

	}

}

public class DateTimeOffsetConverter : ValueConverter<DateTimeOffset, DateTimeOffset>
{

	public DateTimeOffsetConverter() : base(
			v => v.UtcDateTime,
			v => v) { }

}