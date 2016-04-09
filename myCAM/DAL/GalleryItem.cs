namespace myCAM.DAL
{
    public class GalleryItem
    {
        public int GalleryItemId { get; set; }

        public int GalleryId { get; set; } 

        public int ItemId { get; set; }

        public string Note { get; set; }

        public virtual Gallery Gallery { get; set; }
    }
}