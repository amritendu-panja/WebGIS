﻿using Common.Dtos;
using Common.Settings;
using Microsoft.Extensions.Options;
using System.Threading;
using Web.User.Clients;

namespace Web.User.Services
{
    public class AuthService
    {
        private readonly IAuthenticationClient _client;
        private readonly ILogger<AuthService> _logger;
        private readonly AppSettings _appSettings;

        public AuthService(IAuthenticationClient client, ILogger<AuthService> logger, IOptions<AppSettings> appSettings)
        {
            _client = client;
            _logger = logger;
            _appSettings = appSettings.Value;
        }

        public async Task<LoginResponseDto> LoginAsync(string username, string password, CancellationToken cancellationToken)
        {
            LoginRequest request = new LoginRequest
            {
                Username = username,
                Password = password
            };

            return await _client.Login(request, _appSettings.Security.ApiKey, cancellationToken);
        }

        public async Task<ApplicationUserResponseDto> RegisterAsync(string email, string userName, string password, CancellationToken cancellationToken)
        {
            CreateApplicationUserCommand command = new CreateApplicationUserCommand()
            {
                Email = email,
                UserName = userName,
                PasswordSalt = password
            };

            return await _client.Register(command, _appSettings.Security.ApiKey, cancellationToken);
        }

        public async Task<LogoutResponseDto> LogoutAsync(string userId, string accessToken, CancellationToken cancellationToken)
        {
            LogoutRequest logoutRequest = new LogoutRequest
            {
                UserId = Guid.Parse(userId)
            };

            return await _client.Logout(logoutRequest, _appSettings.Security.ApiKey, accessToken, cancellationToken);
        }
    }
}
