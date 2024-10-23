using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocStats.Persistence
{
    public static class FileManagerFactory
    {
        public static IFileManager? CreateForPath(string path)
        {
            if (Path.GetExtension(path) == ".pdf")
            {
                return new PdfFileManager(path);
            }
            else if (Path.GetExtension(path) == ".txt")
            {
                return new TextFileManager(path);
            }
            else
            {
                return null;
            }
        }
    }
}
