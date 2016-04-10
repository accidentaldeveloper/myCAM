using System.Collections;
using System.Collections.Generic;
using myCAM.Queries;

namespace myCAM.Models
{
    public class GalleryViewModel
    {
        public int GalleryId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IEnumerable<GalleryItemInfo> Items { get; set; }
    }

    public class GalleryItemInfo
    {
        public int ItemId { get; set; }

        public GoodItemData GoodItemData { get; set; }

        ////public string Name { get; set; }

        ////public string Artist { get; set; }

        ////public string ImageUrl { get; set; }

        ////public string ThumbnailUrl { get; set; }
        
        public string Note { get; set; }
    }
}