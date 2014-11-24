using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Word.Api.Converters;
using Word.Api.Model;
using Word.SpireDoc.Converters;

namespace Word.SpireDoc.Test.Converters {
    [TestClass]
    public class HtmlConverterTest {
        private const string FileName = "Source/TestDocx.docx";

        [TestMethod]
        public void ConvStreamTest() {
            IHtmlConverter converter = new HtmlConverter();

            using (var stream = File.Open(FileName, FileMode.Open))
            {
                string tags = converter.Conv(stream, FormatType.Docx);

                Assert.IsFalse(string.IsNullOrEmpty(tags));
            }
        }

        [TestMethod]
        public void ConvFileNameTest()
        {
            IHtmlConverter converter = new HtmlConverter();

            string tags = converter.Conv(FileName, FormatType.Docx);

            Assert.IsFalse(string.IsNullOrEmpty(tags));
        }

        [TestMethod]
        public void ConvFileNameToFileTest()
        {
            IHtmlConverter converter = new HtmlConverter();

            converter.Conv(FileName, string.Format("{0}.html", Guid.NewGuid()), FormatType.Docx);
        }
    }
}