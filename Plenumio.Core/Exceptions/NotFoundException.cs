using System;

namespace Plenumio.Core.Exceptions {

    public sealed class NotFoundException : ServiceException {
        public string? Resource { get; }
        public object? Key { get; }

        public NotFoundException(string message, string? resource = null, object? key = null)
            : base(message) {
            Resource = resource;
            Key = key;
        }
    }
}
