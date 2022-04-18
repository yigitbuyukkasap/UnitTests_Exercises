using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        private Mock<IVıdeoRepository> _repo;
        private Mock<IFileReader> _fileReader;
        private VideoService _videoService;

        [SetUp]
        public void SetUp()
        {
            _repo = new Mock<IVıdeoRepository>();
            _fileReader = new Mock<IFileReader>();
            _videoService = new VideoService(_fileReader.Object,_repo.Object); ;
        }

        [Test]
        public void ReaderVideoTitle_EmptyFile_ReturnError()
        {
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            var service = new VideoService(_fileReader.Object);
            var result = service.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        [Test]
        public void GetUnProcessedVideosAsCsv_AllVideosAreProcessed_ReturnAnEmptyString() 
        {
            _repo.Setup(r => r.GetUnProcessedVideos()).Returns(new List<Video>());

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo(""));

        }

        [Test]
        public void GetUnProcessedVideosAsCsv_AFewUnprocessedVideos_ReturnAStringWithIdOfUnProcessedVideos() 
        {
            _repo.Setup(r => r.GetUnProcessedVideos()).Returns(new List<Video> {
                 new Video { Id = 1 },
                 new Video { Id = 2 },
                 new Video { Id = 3 },
            });

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo("1,2,3"));

        }
    }
}
