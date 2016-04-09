using System.ComponentModel.DataAnnotations;

namespace myCAM.Models
{
    public class CreateGalleryModel
    {
        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        public string Description { get; set; } 
    }
}