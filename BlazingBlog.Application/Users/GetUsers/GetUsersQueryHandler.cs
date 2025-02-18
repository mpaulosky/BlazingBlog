// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     GetUserQueryHandler.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application
// =======================================================

namespace BlazingBlog.Application.Users.GetUsers;

public class GetUsersQueryHandler : IQueryHandler<GetUsersQuery, List<UserResponse>>
{

	private readonly IUserRepository _userRepository;

	private readonly IUserService _userService;

	public GetUsersQueryHandler(IUserRepository userRepository, IUserService userService)
	{
		_userRepository = userRepository;
		_userService = userService;
	}

	public async Task<Result<List<UserResponse>>> Handle(GetUsersQuery request,
			CancellationToken cancellationToken)
	{

		if (!await _userService.IsCurrentUserInRoleAsync("Admin"))
		{

			return Result.Fail<List<UserResponse>>("You're not allowed to see all users.");

		}

		var users = await _userRepository.GetAllUsersAsync();

		var response = new List<UserResponse>();

		foreach (var user in users)
		{

			var userResponse = user.Adapt<UserResponse>();

			userResponse.Roles = string.Join(", ", await _userService.GetUserRolesAsync(user.Id));

			response.Add(userResponse);

		}

		return response;

	}

}
