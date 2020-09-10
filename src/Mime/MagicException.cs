using System;

namespace HeyRed.Mime
{
    public class MagicException : Exception
    {
        public MagicException()
        {
        }

        public MagicException(string message) : base(message)
        {
        }

        public MagicException(string message, string additionalInfo) : base(message ?? additionalInfo)
        {
        }

        public MagicException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
