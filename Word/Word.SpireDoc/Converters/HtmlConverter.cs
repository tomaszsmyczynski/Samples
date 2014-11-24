using System;
using System.IO;
using Spire.Doc;
using Word.Api.Converters;
using Word.Api.Model;

namespace Word.SpireDoc.Converters {
    public class HtmlConverter : IHtmlConverter {
        public string Conv(Stream stream, FormatType format) {
            Document document;

            switch (format) {
                case FormatType.Doc:
                    document = new Document(stream, FileFormat.Doc);
                    break;
                case FormatType.Docx:
                    document = new Document(stream, FileFormat.Docx);
                    break;
                default:
                    throw new NotImplementedException();
            }

            using (var returnStream = new MemoryStream()) {
                document.SaveToStream(returnStream, FileFormat.Html);
                returnStream.Position = 0;
                using (var streamReader = new StreamReader(returnStream)) return streamReader.ReadToEnd();
            }
        }

        public string Conv(string fileName, FormatType format) {
            Document document;

            switch (format) {
                case FormatType.Doc:
                    document = new Document(fileName, FileFormat.Doc);
                    break;
                case FormatType.Docx:
                    document = new Document(fileName, FileFormat.Docx);
                    break;
                default:
                    throw new NotImplementedException();
            }

            using (var returnStream = new MemoryStream()) {
                document.SaveToStream(returnStream, FileFormat.Html);
                returnStream.Position = 0;
                using (var streamReader = new StreamReader(returnStream)) return streamReader.ReadToEnd();
            }
        }

        public void Conv(string sourceFileName, string destinationFileName, FormatType format) {
            Document document;

            switch (format)
            {
                case FormatType.Doc:
                    document = new Document(sourceFileName, FileFormat.Doc);
                    break;
                case FormatType.Docx:
                    document = new Document(sourceFileName, FileFormat.Docx);
                    break;
                default:
                    throw new NotImplementedException();
            }

            document.SaveToFile(destinationFileName, FileFormat.Html);
        }
    }
}