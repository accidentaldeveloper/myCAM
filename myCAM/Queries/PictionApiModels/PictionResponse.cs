﻿using Newtonsoft.Json;

namespace myCAM.Queries.PictionApiModels
{
    public class PictionResponse
    {
        ////public S s { get; set; }

        [JsonProperty("r")]
        public ItemInformation[] Results { get; set; }
    }

    ////public class S
    ////{
    ////    public string n { get; set; }
    ////    public string q { get; set; }
    ////    public string o { get; set; }
    ////    public string ss { get; set; }
    ////    public string d { get; set; }
    ////    public string t { get; set; }
    ////    public string rt { get; set; }
    ////    public string rw { get; set; }
    ////    public string tv { get; set; }
    ////    public string m { get; set; }
    ////    public string c { get; set; }
    ////    public string srt { get; set; }
    ////}

    ////public class R
    ////{
    ////    public string id { get; set; }
    ////    public string t { get; set; }
    ////    public string w { get; set; }
    ////    public string h { get; set; }
    ////    public string n { get; set; }
    ////    public string c { get; set; }
    ////    public Gr[] gr { get; set; }
    ////    public string v { get; set; }
    ////    public I[] i { get; set; }
    ////    public string x { get; set; }
    ////    public string a { get; set; }
    ////    public Wq wq { get; set; }
    ////    public O o { get; set; }
    ////}

    ////public class Wq
    ////{
    ////    public _1 _1 { get; set; }
    ////}

    ////public class _1
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

    ////public class I
    ////{
    ////    public string thumbnail { get; set; }
    ////    public string tsize { get; set; }
    ////}
}