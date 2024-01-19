using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_Integrador_MeLoLLevo.Utils
{

    public class Detail
    {
        [JsonProperty("quantity", NullValueHandling = NullValueHandling.Ignore)]
        public int quantity { get; set; }
        [JsonProperty("variantId", NullValueHandling = NullValueHandling.Ignore)]
        public int variantId { get; set; }
        [JsonProperty("cost", NullValueHandling = NullValueHandling.Ignore)]
        public int cost { get; set; }
    }

    public class Reception
    {
        [JsonProperty("document", NullValueHandling = NullValueHandling.Ignore)]
        public string document { get; set; }
        [JsonProperty("officeId", NullValueHandling = NullValueHandling.Ignore)]
        public int officeId { get; set; }
        [JsonProperty("documentNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string documentNumber { get; set; }
        [JsonProperty("note", NullValueHandling = NullValueHandling.Ignore)]
        public string note { get; set; }
        [JsonProperty("details", NullValueHandling = NullValueHandling.Ignore)]
        public List<Detail> details { get; set; }
    }


    public partial class details
    {
        public int quantity { get; set; }
        public int variantId { get; set; }
        public string serialNumber { get; set; }
        public int cost { get; set; }

    }

    public partial class detailsConsumo
    {
        public string detailId { get; set; }
        public int quantity { get; set; }
    }

    public partial class detailsTraspaso
    {
        public int quantity { get; set; }
        public string code { get; set; }
        public float netUnitValue { get; set; }
    }
}
