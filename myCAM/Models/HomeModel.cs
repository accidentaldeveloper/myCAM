using System.Collections;
using System.Collections.Generic;

namespace myCAM.Models
{
    public class HomeModel
    {
        public IEnumerable<GalleryModel> UserGalleries { get; set; } = new List<GalleryModel>();
    }

    public class GalleryModel
    {
        ////public Type { get; set; }
    }
}