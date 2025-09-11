using Microsoft.AspNetCore.Identity;
using Plenumio.Application.DTOs.Tags;
using Plenumio.Application.DTOs.Tags.Requests;
using Plenumio.Application.DTOs.Tags.Responses;
using Plenumio.Application.DTOs.Users;
using Plenumio.Application.DTOs.Users.Requests;
using Plenumio.Application.DTOs.Users.Responses;
using Plenumio.Application.Interfaces;
using Plenumio.Core.Entities;
using Plenumio.Core.Enums;
using Plenumio.Core.Exceptions;
using Plenumio.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Services {
    public class UserService(
            IUnitOfWork uof,
            ISlugGenerator slugGenerator,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IQueryDispatcher queryDispatcher
        ) : IUserService {
        public async Task<RegisterUserResponse> CreateUserAsync(RegisterUserRequest request) {
            string usernameSlug = slugGenerator.GenerateUsername(request.Username);

            var user = new ApplicationUser {
                DisplayedName = request.DisplayedName.Trim(),
                UserName = usernameSlug,
                Email = request.Email.Trim()
            };

            var result = await userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded) {
                var codes = result.Errors.Select(e => e.Code).ToHashSet(StringComparer.OrdinalIgnoreCase);
                if (codes.Contains("DuplicateUserName"))
                    throw new ConflictException("Username already taken. Choose a different one.");
                if (codes.Contains("DuplicateEmail"))
                    throw new ConflictException("Email already in use.");

                var messages = result.Errors.Select(e => e.Description).ToArray();
                throw new ValidationException("Registration failed.", new Dictionary<string, string[]> {
                    ["Identity"] = messages
                });
            }

            return new RegisterUserResponse {
                Id = user.Id,
                Username = user.UserName
            };
        }

        public async Task<LoginUserResponse?> LoginUserAsync(LoginUserRequest request) {
            var result = await signInManager.PasswordSignInAsync(
                request.Username,
                request.Password,
                request.RememberMe,
                lockoutOnFailure: false
            );

            if (!result.Succeeded) return null;

            var user = await userManager.FindByNameAsync(request.Username);
            return new LoginUserResponse { 
                UserId = user!.Id, 
                Username = user.UserName! 
            };
        }

        public async Task LogoutAsync() {
            await signInManager.SignOutAsync();
        }

        public async Task<GetUserProfileResponse?> GetUserProfile(string username, Guid? currentUserId) {
            var request = new GetUserProfileRequest {
                Username = username,
                CurrentUserId = currentUserId
            };
            return await queryDispatcher.SendAsync<GetUserProfileRequest, GetUserProfileResponse>(request);
        }

        public async Task<IEnumerable<UserSummaryDto>> GetUsersAsync(UserFilterDto filters, Guid? userId) {
            var query = new GetUsersRequest {
                Filters = filters,
                UserId = userId
            };

            return await queryDispatcher.SendAsync<GetUsersRequest, IEnumerable<UserSummaryDto>>(query);
        }

        public async Task<IEnumerable<UserSummaryDto>> GetAllUsersAsync(UserFilterDto filters, Guid? userId) {
            var query = new GetUsersRequest {
                Filters = filters with { SearchTerm = "" },
                UserId = userId
            };

            return await queryDispatcher.SendAsync<GetUsersRequest, IEnumerable<UserSummaryDto>>(query);
        }

        

    }
}
