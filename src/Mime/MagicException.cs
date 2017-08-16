using System;

namespace HeyRed.Mime
{
    internal class MagicException : Exception
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
    }
}
