using PaymentImporter.Services.Helpers;
using NUnit.Framework;

namespace PaymentImporter.Services.Tests.Helpers
{
    public class FileHelperUnitTests
    {
        [Test]
        public void FileHelperUnitTests_CanGetFileExtentionWithoutDot()
        {
            var actual = FileHelper.GetSimpleExtension(".csv");

            Assert.AreEqual("csv", actual);
        }
    }
}
