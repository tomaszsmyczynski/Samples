using System;
using System.IO;
using GemBox.Document;
using Word.Api.Converters;
using Word.Api.Model;

namespace Word.GemBox.Converters {
    public class HtmlConverter : IHtmlConverter {
        public HtmlConverter() {
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
        }

        public string Conv(Stream stream, FormatType format) {
            DocumentModel document;

            switch (format) {
                case FormatType.Doc:
                    document = DocumentModel.Load(stream, LoadOptions.DocDefault);
                    break;
                case FormatType.Docx:
                    document = DocumentModel.Load(stream, LoadOptions.DocxDefault);
                    break;
                default:
                    throw new NotImplementedException();
            }

            using (var returnStream = new MemoryStream()) {
                document.Save(returnStream, SaveOptions.HtmlDefault);
                returnStream.Position = 0;
                using (var streamReader = new StreamReader(returnStream)) return streamReader.ReadToEnd();
            }
        }

        public string Conv(string fileName, FormatType format) {
            DocumentModel document;

            switch (format) {
                case FormatType.Doc:
                    document = DocumentModel.Load(fileName, LoadOptions.DocDefault);
                    break;
                case FormatType.Docx:
                    document = DocumentModel.Load(fileName, LoadOptions.DocxDefault);
                    break;
                default:
                    throw new NotImplementedException();
            }

            using (var returnStream = new MemoryStream()) {
                document.Save(returnStream, SaveOptions.HtmlDefault);
                returnStream.Position = 0;
                using (var streamReader = new StreamReader(returnStream)) return streamReader.ReadToEnd();
            }
        }

        public void Conv(string sourceFileName, string destinationFileName, FormatType format) {
            DocumentModel document;

            switch (format)
            {
                case FormatType.Doc:
                    document = DocumentModel.Load(sourceFileName, LoadOptions.DocDefault);
                    break;
                case FormatType.Docx:
                    document = DocumentModel.Load(sourceFileName, LoadOptions.DocxDefault);
                    break;
                default:
                    throw new NotImplementedException();
            }

            document.Save(destinationFileName, SaveOptions.HtmlDefault);
        }
    }
}