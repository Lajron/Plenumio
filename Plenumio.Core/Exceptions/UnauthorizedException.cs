using System;

namespace Plenumio.Core.Exceptions {
    
    public sealed class UnauthorizedException : ServiceException {
        public UnauthorizedException(string message = "Unauthorized.") : base(message) { }
    }
}
