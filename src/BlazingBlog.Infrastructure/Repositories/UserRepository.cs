// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     UserRepository.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Infrastructure
// =======================================================

namespace BlazingBlog.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{

	private readonly UserManager<User> _userManager;

	public UserRepository(UserManager<User> userManager)
	{

		_userManager = userManager;

	}

	public async Task<List<IUser>> GetAllUsersAsync()
	{

		return await _userManager.Users.Select(user => (IUser)user).ToListAsync();

	}

	public async Task<IUser?> GetUserByIdAsync(string userId)
	{

		return await _userManager.FindByIdAsync(userId);

	}

}
