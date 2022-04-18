using Moq;
using NUnit.Framework;
using System.Net;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class InstallerHalperTests
    {
        private Mock<IFileDownloader> _fileDownloader;
        private InstallerHelper _InstallerHelper;

        [SetUp]
        public void SetUp()
        {
            _fileDownloader = new Mock<IFileDownloader>();
            _InstallerHelper = new InstallerHelper(_fileDownloader.Object);
        }

        [Test]
        public void DownloadInstaller_DownloadFails_ReturnFalse() 
        {
            _fileDownloader.Setup(fd => 
                fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>()))
                .Throws<WebException>();

            var result = _InstallerHelper.DownloadInstaller("customer","installer");
            Assert.That(result, Is.False);
        }

        [Test]
        public void DownloadInstaller_DownloadComplate_ReturnTrue() 
        {
            var result = _InstallerHelper.DownloadInstaller("customer","installer");
            Assert.That(result, Is.True);
        }

    }
}
