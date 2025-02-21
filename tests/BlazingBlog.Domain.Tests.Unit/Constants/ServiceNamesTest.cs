// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     ServiceNamesTest.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Domain.Tests.Unit
// =======================================================

namespace BlazingBlog.Domain.Constants;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(ServiceNames))]
public class ServiceNamesTest
{

[Fact]
public void Servername_ShouldBePosts()
{
    ServiceNames.Servername.Should().Be("posts");
}

[Fact]
public void DatabaseName_ShouldBePostDatabase()
{
    ServiceNames.DatabaseName.Should().Be("post-database");
}

[Fact]
public void Migration_ShouldBeDatabaseMigration()
{
    ServiceNames.Migration.Should().Be("database-migration");
}

[Fact]
public void OutputCache_ShouldBeOutputCache()
{
    ServiceNames.OutputCache.Should().Be("output-cache");
}

}