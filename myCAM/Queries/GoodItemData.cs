using System.Linq;
using myCAM.Queries.PictionApiModels;

namespace myCAM.Queries
{
    public class GoodItemData
    {
        public string Id { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public string Artist { get; set; }

        public string  ThumbnailUrl { get; set; }

        public static GoodItemData CreateFromItemInformation(ItemInformation itemInformation)
        {
            var metadata = itemInformation.MetadataItems;
            var name = metadata.FirstOrDefault(item => item.DisplayName == "Name/Title")?.Value;
            var artist = metadata.FirstOrDefault(item => item.Name == "PRIMARY_MAKER_ROLE")?.Value;
            var wqUrl = itemInformation.WebQualityImages.First.Url;
            var thumb = itemInformation.ThumbnailImages.FirstOrDefault()?.Url;

            var imageUrl = $"{ImageDataRequest.BaseUrl}{wqUrl}";
            var thumbUrl = $"{ImageDataRequest.BaseUrl}{thumb}";
            var data = new GoodItemData
            {
                Id = itemInformation.ItemId,
                Name = name,
                Artist = artist,
                ImageUrl = imageUrl,
                ThumbnailUrl = thumbUrl
            };
            return data;
        }
    }
}