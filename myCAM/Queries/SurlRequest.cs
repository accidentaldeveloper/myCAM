using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using myCAM.Queries.PictionApiModels;
using Newtonsoft.Json;

namespace myCAM.Queries
{
    public class SurlRequest
    {
        public static async Task<string> GetSurl(string username, string password)
        {
            var url = $"{ImageDataRequest.BaseUrl}!soap.jsonget?n=Piction_login&USERNAME={username}&PASSWORD={password}";
            using (var client = new HttpClient())
            {
                var responseMessage = await client.GetAsync(url);
                var theBody = await responseMessage.Content.ReadAsStringAsync();
                dynamic myStuff = JsonConvert.DeserializeObject(theBody);
                return myStuff.SURL;
            }

        }
    }
}