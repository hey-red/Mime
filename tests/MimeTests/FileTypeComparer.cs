using HeyRed.MimeGuesser;
using System.Collections.Generic;

namespace MimeTests
{
    public class FileTypeComparer : IEqualityComparer<FileType>
    {
        public bool Equals(FileType x, FileType y)
        {
            return
                x.MimeType == y.MimeType &&
                x.Extension == y.Extension;
        }

        public int GetHashCode(FileType obj)
        {
            return
                obj.MimeType.GetHashCode() +
                obj.Extension.GetHashCode();
        }
    }
}
