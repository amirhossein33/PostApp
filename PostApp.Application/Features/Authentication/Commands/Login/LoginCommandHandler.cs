using MediatR;
using PostApp.Application.Common.Exceptions;
using PostApp.Application.Interfaces.Repositories;
using PostApp.Application.Interfaces.Services;
using PostApp.Domain.Constants;

namespace PostApp.Application.Features.Authentication.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResult>
{
    private readonly IManagerRepository _managerRepository;
    private readonly IDriverRepository _driverRepository;
    private readonly IJwtService _jwtService;
    private readonly IUnitOfWork _unitOfWork;

    public LoginCommandHandler(
        IManagerRepository managerRepository,
        IDriverRepository driverRepository,
        IJwtService jwtService,
        IUnitOfWork unitOfWork)
    {
        _managerRepository = managerRepository;
        _driverRepository = driverRepository;
        _jwtService = jwtService;
        _unitOfWork = unitOfWork;
    }

    public async Task<LoginResult> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        // First check if user exists and get user info based on role
        if (request.Role == UserRoles.Manager)
        {
            var manager = await _managerRepository.FirstOrDefaultAsync(m => m.Username == request.Username, cancellationToken);

            if (manager == null || !manager.IsActive)
            {
                throw new AuthenticationException("Invalid username or password");
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, manager.PasswordHash))
            {
                throw new AuthenticationException("Invalid username or password");
            }

            var token = _jwtService.GenerateToken(manager.Id.ToString(), manager.Username, UserRoles.Manager);
            var expiresAt = DateTime.UtcNow.AddMinutes(60); // This should come from configuration

            // Update last login
            manager.LastLoginAt = DateTime.UtcNow;
            _managerRepository.Update(manager);
            await _unitOfWork.SaveChangesAsync();

            return new LoginResult
            {
                Token = token,
                RefreshToken = Guid.NewGuid().ToString(),
                ExpiresAt = expiresAt,
                Role = UserRoles.Manager,
                Username = manager.Username,
                UserId = manager.Id,
                Name = manager.Name
            };
        }
        else if (request.Role == UserRoles.Driver)
        {
            var driver = await _driverRepository.FirstOrDefaultAsync(d => d.Username == request.Username, cancellationToken);

            if (driver == null || !driver.Active)
            {
                throw new AuthenticationException("Invalid username or password");
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, driver.PasswordHash))
            {
                throw new AuthenticationException("Invalid username or password");
            }

            var token = _jwtService.GenerateToken(driver.Id.ToString(), driver.Username, UserRoles.Driver);
            var expiresAt = DateTime.UtcNow.AddMinutes(60); // This should come from configuration

            // Update last login
            driver.LastLoginAt = DateTime.UtcNow;
            _driverRepository.Update(driver);
            await _unitOfWork.SaveChangesAsync();

            return new LoginResult
            {
                Token = token,
                RefreshToken = Guid.NewGuid().ToString(),
                ExpiresAt = expiresAt,
                Role = UserRoles.Driver,
                Username = driver.Username,
                UserId = driver.Id,
                Name = driver.Name
            };
        }
        else
        {
            throw new AuthenticationException("Invalid role specified");
        }
    }
}