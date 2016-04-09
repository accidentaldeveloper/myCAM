using System.Collections;
using System.Collections.Generic;

namespace myCAM.Models
{
    public class GalleryViewModel
    {


        public string Title { get; set; }

        public string Description { get; set; }

        public IEnumerable<GalleryItemInfo> Items { get; set; }
    }

    public class GalleryItemInfo
    {
        public int ItemId { get; set; }

        public string Notes { get; set; }
    }
}