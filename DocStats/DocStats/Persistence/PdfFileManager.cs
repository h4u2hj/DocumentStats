using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocStats.Persistence
{
    internal class PdfFileManager : IFileManager
    {

        private readonly string _path;

        public PdfFileManager(string path)
        {
            _path = path;
        }

        public string Load()
        {
            using PdfReader reader = new PdfReader(_path);
            using PdfDocument document = new PdfDocument(reader);

            StringBuilder text = new StringBuilder();
            try
            {
                for (int i = 1; i < +document.GetNumberOfPages(); i++)
                {
                    PdfPage page = document.GetPage(i);
                    text.Append(PdfTextExtractor.GetTextFromPage(page));
                }
            }
            catch (IOException ex)
            {

                throw new FileManagerException(ex.Message, ex);
            }
            return text.ToString();
        }
    }
}
