// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     ApplicationDbContext.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Infrastructure
// =======================================================

namespace BlazingBlog.Infrastructure;

public class ApplicationDbContext : IdentityDbContext<User>
{

	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

	public DbSet<Article> Articles { get; set; }

}