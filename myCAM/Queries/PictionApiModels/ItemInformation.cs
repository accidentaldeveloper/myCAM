using Newtonsoft.Json;

namespace myCAM.Queries.PictionApiModels
{
    public class ItemInformation
    {
        [JsonProperty("id")]
        public string ItemId { get; set; }
        ////public string t { get; set; }
        ////public string w { get; set; }
        ////public string h { get; set; }

        [JsonProperty("n")]
        public string FileName { get; set; }
        ////public string c { get; set; }
        ////public Gr[] gr { get; set; }
        ////public string v { get; set; }
        [JsonProperty("i")]
        public ThumbnailImageData[] ThumbnailImages { get; set; }
        ////public string x { get; set; }
        ////public string a { get; set; }

        [JsonProperty("wq")]
        public WebQualityImages WebQualityImages { get; set; }
        ////public O o { get; set; }

        [JsonProperty("m")]
        public MetadataItem[] MetadataItems { get; set; }
    }

    public class WebQualityImages
    {
        [JsonProperty("1")]
        public WebQualityImage First { get; set; }
    }

    public class WebQualityImage
    {
        [JsonProperty("u")]
        public string Url { get; set; }
        ////public string t { get; set; }
        ////public string mt { get; set; }
        ////public string p { get; set; }
        ////public string f { get; set; }
        ////public string na { get; set; }
        ////public string pn { get; set; }
        ////public string sz { get; set; }
    }

    ////public class O
    ////{
    ////    public _4 _4 { get; set; }
    ////    public _3 _3 { get; set; }
    ////}

    ////public class _4
    ////{
    ////    public string u { get; set; }
    ////    public string t { get; set; }
    ////    public string mt { get; set; }
    ////    public string p { get; set; }
    ////    public string f { get; set; }
    ////    public string na { get; set; }
    ////    public string pn { get; set; }
    ////    public string sz { get; set; }
    ////}

    ////public class _3
    ////{
    ////    public string u { get; set; }
    ////    public string t { get; set; }
    ////    public string mt { get; set; }
    ////    public string p { get; set; }
    ////    public string f { get; set; }
    ////    public string na { get; set; }
    ////    public string pn { get; set; }
    ////    public string sz { get; set; }
    ////}

    ////public class Gr
    ////{
    ////    public string d { get; set; }
    ////    public string f { get; set; }
    ////}

    public class ThumbnailImageData
    {
        [JsonProperty("thumbnail")]
        public string Url { get; set; }
        [JsonProperty("tsize")]
        public string Size { get; set; }
    }

    public class MetadataItem
    {
        [JsonProperty("v")]
        public string Value { get; set; }
        [JsonProperty("c")]
        public string Name { get; set; }
        [JsonProperty("d")]
        public string DisplayName { get; set; }
        ////public string t { get; set; }
        ////public string i { get; set; }
        ////public string xpk { get; set; }
        ////public string rf { get; set; }
        ////public string p { get; set; }
        ////public string id { get; set; }
        ////public string ro { get; set; }
        ////public string dc { get; set; }
        ////public string du { get; set; }
        ////public string mpk { get; set; }
        ////public string lng { get; set; }
    }

}