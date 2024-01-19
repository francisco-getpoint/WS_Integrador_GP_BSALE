using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_Integrador_MeLoLLevo.Utils
{
    public class OfficeR
    {
        [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
        public string href { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string id { get; set; }
    }

    public class UserR
    {
        [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
        public string href { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string id { get; set; }
    }

    public class ShippingType
    {
        [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
        public string href { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string id { get; set; }
    }

    public class Guide
    {
        [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
        public string href { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string id { get; set; }
    }

    public class DetailsR
    {
        [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
        public string href { get; set; }
    }

    public class RespGuiaIntegracion
    {

        [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
        public string href { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int id { get; set; }

        [JsonProperty("shippingDate", NullValueHandling = NullValueHandling.Ignore)]
        public int shippingDate { get; set; }

        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public string address { get; set; }

        [JsonProperty("municipality", NullValueHandling = NullValueHandling.Ignore)]
        public string municipality { get; set; }

        [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
        public string city { get; set; }

        [JsonProperty("recipient", NullValueHandling = NullValueHandling.Ignore)]
        public string recipient { get; set; }

        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public int state { get; set; }

        [JsonProperty("office", NullValueHandling = NullValueHandling.Ignore)]
        public OfficeR office { get; set; }

        [JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
        public UserR user { get; set; }

        [JsonProperty("shipping_type", NullValueHandling = NullValueHandling.Ignore)]
        public ShippingType shipping_type { get; set; }

        [JsonProperty("guide", NullValueHandling = NullValueHandling.Ignore)]
        public Guide guide { get; set; }

        [JsonProperty("details", NullValueHandling = NullValueHandling.Ignore)]
        public DetailsR details { get; set; }
    }
}
