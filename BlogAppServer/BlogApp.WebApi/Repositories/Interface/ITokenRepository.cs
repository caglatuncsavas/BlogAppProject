﻿using Microsoft.AspNetCore.Identity;

namespace BlogApp.WebApi.Repositories.Interface;

public interface ITokenRepository
{
   string CreateJwtToken(IdentityUser user, List<string> roles);
}
