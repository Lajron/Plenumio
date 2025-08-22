using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Contracts.DTOs {
    public record UserDto(
        int Id,
        string Username,
        string? AvatarUrl
    );
    
}
