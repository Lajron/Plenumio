using System;
using System.Collections.Generic;

namespace Plenumio.Core.Exceptions {
    public sealed class ValidationException : ServiceException {
        public IDictionary<string, string[]> Errors { get; }

        public ValidationException(string message)
            : base(message) {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(string message, IDictionary<string, string[]> errors)
            : base(message) {
            Errors = errors;
        }
    }
}