using HeyRed.Mime;

using Xunit;

namespace MimeTests
{
    public class MagicMeta
    {
        [Fact]
        public void CheckVersion() => Assert.Equal(530, Magic.Version);

        [Fact]
        public void GetFlags()
        {
            using var magic = new Magic(MagicOpenFlags.MAGIC_MIME_TYPE);

            Assert.Equal(MagicOpenFlags.MAGIC_MIME_TYPE, magic.GetFlags());
        }

        [Fact]
        public void SetFlags()
        {
            var flags = MagicOpenFlags.MAGIC_MIME_TYPE | MagicOpenFlags.MAGIC_MIME_ENCODING;

            using var magic = new Magic(MagicOpenFlags.MAGIC_NONE);
            magic.SetFlags(flags);

            Assert.Equal(flags, magic.GetFlags());
        }
    }
}
