namespace HeyRed.Mime
{
    /// <summary>
    /// The various limits.
    /// </summary>
    public enum MagicParams
    {
        /// <summary>
        /// The parameter controls how many levels of recursion will be followed for indirect magic entries.
        /// </summary>
        MAGIC_PARAM_INDIR_MAX = 0,

        /// <summary>
        /// The parameter controls the maximum number of calls for name/use.
        /// </summary>
        MAGIC_PARAM_NAME_MAX,

        /// <summary>
        /// The parameter controls how many ELF program sections will be processed.
        /// </summary>
        MAGIC_PARAM_ELF_PHNUM_MAX,

        /// <summary>
        /// The parameter controls how many ELF sections will be processed.
        /// </summary>
        MAGIC_PARAM_ELF_SHNUM_MAX,

        /// <summary>
        /// The parameter controls how many ELF notes will be processed.
        /// </summary>
        MAGIC_PARAM_ELF_NOTES_MAX,

        /// <summary>
        /// Regex limit.
        /// </summary>
        MAGIC_PARAM_REGEX_MAX,

        /// <summary>
        /// The parameter controls how many bytes read from file.
        /// </summary>
        MAGIC_PARAM_BYTES_MAX
    }
}