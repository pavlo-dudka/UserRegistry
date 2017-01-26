using System;

namespace UserRegistry.Core.Repositories
{
    public class UpdateException : Exception
    {
        public UpdateException()
        {
        }

        public UpdateException(string message)
            : base(message)
        {
        }

        public UpdateException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
