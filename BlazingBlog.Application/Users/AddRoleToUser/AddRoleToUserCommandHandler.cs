// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     AddRoleToUserCommandHandler.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application
// =======================================================

namespace BlazingBlog.Application.Users.AddRoleToUser;

public class AddRoleToUserCommandHandler : ICommandHandler<AddRoleToUserCommand>
{
	private readonly IUserService _UserService;

	public AddRoleToUserCommandHandler(IUserService userService)
	{

		_UserService = userService;

	}

	public async Task<Result> Handle(AddRoleToUserCommand request, CancellationToken cancellationToken)
	{

		try
		{

			await _UserService.AddRoleToUserAsync(request.UserId, request.RoleName);

			return Result.Ok();

		}
		catch (Exception ex)
		{

			return Result.Fail(ex.Message);

		}

	}

}
