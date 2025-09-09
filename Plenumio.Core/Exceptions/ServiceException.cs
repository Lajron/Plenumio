using System;

namespace Plenumio.Core.Exceptions {
 
    public abstract class ServiceException : Exception {
        protected ServiceException(string message) : base(message) { }
    }
}
