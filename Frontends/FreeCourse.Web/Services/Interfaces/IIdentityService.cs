﻿using System.Threading.Tasks;
using FreeCourse.Shared.Dtos;
using FreeCourse.Web.Models;
using IdentityModel.Client;

namespace FreeCourse.Web.Services.Interfaces
{
	public interface IIdentityService
	{

		Task<Response<bool>> SignIn(SigninInput signinInput);

		Task<TokenResponse> GetAccesTokenByRefreshToken();

		Task RevokeRefreshToken();
        
	}
}

