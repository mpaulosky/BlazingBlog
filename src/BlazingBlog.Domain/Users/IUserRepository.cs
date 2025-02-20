// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     IUserRepository.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Domain
// =======================================================

namespace BlazingBlog.Domain.Users;

public interface IUserRepository
{

	Task<List<IUser>> GetAllUsersAsync();

	Task<IUser?> GetUserByIdAsync(string userId);

}
