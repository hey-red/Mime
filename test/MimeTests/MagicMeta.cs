using HeyRed.Mime;
using Xunit;

namespace MimeTests
{
    public class MagicMeta
    {
        [Fact]
        public void CheckVersion() => Assert.Equal(530, Magic.Version);
    }
}
