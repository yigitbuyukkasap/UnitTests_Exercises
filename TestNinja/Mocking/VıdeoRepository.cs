using System.Collections.Generic;
using System.Linq;

namespace TestNinja.Mocking
{
    public interface IVıdeoRepository
    {
        IEnumerable<Video> GetUnProcessedVideos();
    }

    public class VıdeoRepository : IVıdeoRepository
    {
        public IEnumerable<Video> GetUnProcessedVideos()
        {
            using (var context = new VideoContext())
            {
                var videos =
                    (from video in context.Videos
                     where !video.IsProcessed
                     select video).ToList();
                return videos;
            }
        }
    }
}
