using System;

namespace HeyRed.MimeGuesser
{
    internal class MagicException : Exception
    {
        public MagicException()
        {
        }

        public MagicException(string message) : base(message)
        {
        }
    }
}
