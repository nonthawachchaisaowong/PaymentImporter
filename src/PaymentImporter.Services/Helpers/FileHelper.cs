using System.IO;

namespace PaymentImporter.Services.Helpers
{
    public class FileHelper
    {
        /// <summary>
        ///   Gets the extension without the dot
        /// </summary>
        /// <param name = "fileName">Name of the file.</param>
        /// <returns></returns>
        public static string GetSimpleExtension(string fileName)
        {
            return Path.GetExtension(fileName).Replace(".", "");
        }
    }
}
