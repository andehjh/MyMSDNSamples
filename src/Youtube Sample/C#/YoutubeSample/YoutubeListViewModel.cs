using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeSample
{
    public class YoutubeListViewModel
    {
         /// <summary>
        /// Initializes a new instance of the <see cref="YoutubeListViewModel" /> class.
        /// </summary>
        public YoutubeListViewModel()
        {
            YoutubeItems = new ObservableCollection<YoutubeItem>();
            YoutubeItems.Add(new YoutubeItem { Width = 560, Height = 315, FrameBorder = 0, Source = "http://www.youtube.com/embed/avn7Fxcjoxg" });
            YoutubeItems.Add(new YoutubeItem { Width = 560, Height = 315, FrameBorder = 0, Source = "http://www.youtube.com/embed/tYrND5hMY3A" });
            YoutubeItems.Add(new YoutubeItem { Width = 560, Height = 315, FrameBorder = 0, Source = "  http://www.youtube.com/embed/yxzXFrlVPfc" });
          
        }

        /// <summary>
        /// Gets or sets the youtube item.
        /// </summary>
        /// <value>
        /// The youtube item.
        /// </value>
        public ObservableCollection<YoutubeItem> YoutubeItems { get; set; }
    }
}
