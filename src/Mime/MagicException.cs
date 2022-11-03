using System;

namespace HeyRed.Mime;

/// <summary>
/// An exception class for all libmagic errors.
/// </summary>
public class MagicException : Exception
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public MagicException()
    {
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="message"></param>
    public MagicException(string message) : base(message)
    {
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="message"></param>
    /// <param name="additionalInfo"></param>
    public MagicException(string message, string additionalInfo) : base(message ?? additionalInfo)
    {
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public MagicException(string message, Exception innerException) : base(message, innerException)
    {
    }
}