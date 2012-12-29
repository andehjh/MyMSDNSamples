namespace Windows8.SlideShareSample
{
    class SlideShareViewModel
    {
         /// <summary>
        /// Initializes a new instance of the <see cref="SlideShareViewModel" /> class.
        /// </summary>
        public SlideShareViewModel()
        {
            SlideShareItem = new SlideShareItem { Width = 500, Height = 400, FrameBorder = 0, Source = "http://www.slideshare.net/slideshow/embed_code/15116950?rel=0" };
        }

        /// <summary>
        /// Gets or sets the slide share item.
        /// </summary>
        /// <value>
        /// The slide share item.
        /// </value>
        public SlideShareItem SlideShareItem { get; set; }
    }
}
