using System.IO;
using Word.Api.Model;

namespace Word.Api.Converters {
    public interface IHtmlConverter {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="format"></param>
        /// <returns>html tags</returns>
        string Conv(Stream stream, FormatType format);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="format"></param>
        /// <returns>html tags</returns>
        string Conv(string fileName, FormatType format);

        void Conv(string sourceFileName, string destinationFileName, FormatType format);
    }
}