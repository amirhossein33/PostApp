using MediatR;
using PostApp.Application.Common.Exceptions;
using PostApp.Application.Interfaces.Repositories;
using PostApp.Domain.Constants;
using PostApp.Domain.Entities;

namespace PostApp.Application.Features.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResult>
{
    private readonly IManagerRepository _managerRepository;
    private readonly IDriverRepository _driverRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterCommandHandler(
        IManagerRepository managerRepository,
        IDriverRepository driverRepository,
        IUnitOfWork unitOfWork)
    {
        _managerRepository = managerRepository;
        _driverRepository = driverRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<RegisterResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        // Check if username or email already exists in both tables
        var existingManager = await _managerRepository.FirstOrDefaultAsync(m => m.Username == request.Username, cancellationToken);
        if (existingManager == null)
        {
            existingManager = await _managerRepository.FirstOrDefaultAsync(m => m.Email == request.Email, cancellationToken);
        }

        var existingDriver = await _driverRepository.FirstOrDefaultAsync(m => m.Username == request.Username, cancellationToken) ??
                          await _driverRepository.FirstOrDefaultAsync(m => m.Email == request.Email, cancellationToken);

        if (existingManager != null || existingDriver != null)
        {
            throw new ValidationException("User with this username or email already exists");
        }

        // Hash password
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        if (request.Role == UserRoles.Manager)
        {
            // Check if manager number already exists
            var existingManagerByNumber = await _managerRepository.GetByManagerNumberAsync(request.ManagerNumber!);
            if (existingManagerByNumber != null)
            {
                throw new ValidationException("Manager with this number already exists");
            }

            var manager = new Manager
            {
                Name = request.Name,
                ManagerNumber = request.ManagerNumber!,
                Username = request.Username,
                Email = request.Email,
                PasswordHash = passwordHash,
                CreatedAt = DateTime.UtcNow,
            };

            await _managerRepository.AddAsync(manager);
            await _unitOfWork.SaveChangesAsync();

            return new RegisterResult
            {
                Success = true,
                Message = "Manager registered successfully",
                UserId = manager.Id
            };
        }
        else if (request.Role == UserRoles.Driver)
        {
            // Check if driver number already exists
            var existingDriverByNumber = await _driverRepository.GetByDriverNumberAsync(request.DriverNumber!);
            if (existingDriverByNumber != null)
            {
                throw new ValidationException("Driver with this number already exists");
            }

            var driver = new Driver
            {
                Name = request.Name,
                DriverNumber = request.DriverNumber!,
                Username = request.Username,
                Email = request.Email,
                PasswordHash = passwordHash,
                CreatedAt = DateTime.UtcNow,
                Active = true,
                IsRunning = false
            };

            await _driverRepository.AddAsync(driver);
            await _unitOfWork.SaveChangesAsync();

            return new RegisterResult
            {
                Success = true,
                Message = "Driver registered successfully",
                UserId = driver.Id
            };
        }
        else
        {
            throw new ValidationException("Invalid role specified");
        }
    }
}