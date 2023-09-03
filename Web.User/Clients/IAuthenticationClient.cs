﻿using Common.Dtos;
using Refit;

namespace Web.User.Clients
{
    public interface IAuthenticationClient
    {
        [Post("/api/auth/register")]
        Task<ApplicationUserResponseDto> Register([Body] CreateApplicationUserCommand command, [Header("XApiKey")] string apiKey, CancellationToken cancellationToken);

        [Post("/api/auth/login")]
        Task<LoginResponseDto> Login([Body] LoginRequest request, [Header("XApiKey")] string apiKey, CancellationToken cancellationToken);

        [Post("/api/auth/logout")]
        Task<LogoutResponseDto> Logout([Body] LogoutRequest request, [Header("XApiKey")] string apiKey, [Authorize("Bearer")] string accessToken,  CancellationToken cancellationToken);

        [Post("/api/auth/refresh")]
        Task<LoginResponseDto> Refresh([Body] LogoutRequest request, [Header("XApiKey")] string apiKey, CancellationToken cancellationToken);
    }
}
