using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using myCAM.Models;

namespace myCAM.DAL
{
    public class Gallery
    {
        public int GalleryId { get; set; }

        public string ApplicationUserId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public virtual ICollection<GalleryItem> Posts { get; set; } = new HashSet<GalleryItem>();

        public ApplicationUser ApplicationUser { get; set; }
    }
}