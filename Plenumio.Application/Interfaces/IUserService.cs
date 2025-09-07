using Plenumio.Application.DTOs.Tags;
using Plenumio.Application.DTOs.Tags.Responses;
using Plenumio.Application.DTOs.Users;
using Plenumio.Application.DTOs.Users.Requests;
using Plenumio.Application.DTOs.Users.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Interfaces {
    public interface IUserService {
        Task<RegisterUserResponse> CreateUserAsync(RegisterUserRequest request);
        Task<LoginUserResponse?> LoginUserAsync(LoginUserRequest request);
        Task LogoutAsync();

        Task<GetUserProfileResponse?> GetUserProfile(string username, Guid? currentUserId);

        Task<IEnumerable<UserSummaryDto>> GetUsersAsync(UserFilterDto filters, Guid? userId);
        Task<IEnumerable<UserSummaryDto>> GetAllUsersAsync(UserFilterDto filters, Guid? userId);

        
    }
}
