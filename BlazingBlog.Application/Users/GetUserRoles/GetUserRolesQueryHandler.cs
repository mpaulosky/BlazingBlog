// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     GetUserRolesQueryHandler.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlazingBlog
// Project Name :  BlazingBlog.Application
// =======================================================

namespace BlazingBlog.Application.Users.GetUserRoles;

public class GetUserRolesQueryHandler : IQueryHandler<GetUserRolesQuery, List<string>>
{

	private IUserService _UserService;

	public GetUserRolesQueryHandler(IUserService userService)
	{

		_UserService = userService;

	}

	public async Task<Result<List<string>>> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
	{

		var roles = await _UserService.GetUserRolesAsync(request.UserId);

		return Result.Ok(roles);

	}

}
