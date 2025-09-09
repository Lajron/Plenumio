using System;

namespace Plenumio.Core.Exceptions {
    public sealed class ForbiddenException : ServiceException {
        public ForbiddenException(string message = "Forbidden.") : base(message) { }
    }
}