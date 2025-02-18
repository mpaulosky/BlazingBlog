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

	private readonly IUserRepository _UserRepository;

	private readonly IUserService _UserService;

	public GetUsersQueryHandler(IUserRepository userRepository, IUserService userService)
	{
		_UserRepository = userRepository;
		_UserService = userService;
	}

	public async Task<Result<List<UserResponse>>> Handle(GetUsersQuery request,
			CancellationToken cancellationToken)
	{

		if (!await _UserService.IsCurrentUserInRoleAsync("Admin"))
		{

			return Result.Fail<List<UserResponse>>("You're not allowed to see all users.");

		}

		var users = await _UserRepository.GetAllUsersAsync();

		var response = new List<UserResponse>();

		foreach (var user in users)
		{

			var userResponse = user.Adapt<UserResponse>();

			userResponse.Roles = string.Join(", ", await _UserService.GetUserRolesAsync(user.Id));

			response.Add(userResponse);

		}

		return response;

	}

}
