using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.DTOs {
    public record OldUserSummaryDto(
        Guid Id,
        string DisplayedName,
        string AvatarUrl,
        bool IsVerified
    );

    public record UserDto(
        int Id,
        string Username,
        string AvatarUrl
    );

}
