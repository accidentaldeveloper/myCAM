using System.Net.Http;
using System.Threading.Tasks;
using myCAM.Queries.PictionApiModels;
using Newtonsoft.Json;

namespace myCAM.Queries
{
    public class ImageDataRequest
    {
        public const string BaseUrl = "http://collections.cincinnatiartmuseum.org/pictiondmz/";
        private readonly int imageId;

        public ImageDataRequest(int imageId)
        {
            this.imageId = imageId;
        }

        public async Task<ItemInformation> GetItemData(string surl)
        {
            var url = $"{BaseUrl}!soap.jsonget?n=image_query&SURL={surl}&SEARCH=UMO:{imageId}&ALL_METADATA=TRUE";
            using (var client = new HttpClient())
            {
                var responseMessage = await client.GetAsync(url);
                var theBody = await responseMessage.Content.ReadAsStringAsync();
                var myStuff = JsonConvert.DeserializeObject<ItemInformation>(theBody);
                return myStuff;
            }
        }
    }
}