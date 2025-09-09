using System;

namespace Plenumio.Core.Exceptions {
    public sealed class ConflictException : ServiceException {
        public ConflictException(string message) : base(message) { }
    }
}