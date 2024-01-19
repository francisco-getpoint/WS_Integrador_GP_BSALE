using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_Integrador_GP_BSALE.Utils
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Product
    {
        [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
        public string href { get; set; }
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string id { get; set; }
    }

    public class AttributeValues
    {
        [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
        public string href { get; set; }
    }

    public class Costs
    {
        [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
        public string href { get; set; }
    }

    public class Variants
    {
        [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
        public string href { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int id { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string description { get; set; }

        [JsonProperty("unlimitedStock", NullValueHandling = NullValueHandling.Ignore)]
        public int unlimitedStock { get; set; }

        [JsonProperty("allowNegativeStock", NullValueHandling = NullValueHandling.Ignore)]
        public int allowNegativeStock { get; set; }

        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public int state { get; set; }

        [JsonProperty("barCode", NullValueHandling = NullValueHandling.Ignore)]
        public string barCode { get; set; }

        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public string code { get; set; }

        [JsonProperty("imagestionCenterCost", NullValueHandling = NullValueHandling.Ignore)]
        public int imagestionCenterCost { get; set; }

        [JsonProperty("imagestionAccount", NullValueHandling = NullValueHandling.Ignore)]
        public int imagestionAccount { get; set; }

        [JsonProperty("imagestionConceptCod", NullValueHandling = NullValueHandling.Ignore)]
        public int imagestionConceptCod { get; set; }

        [JsonProperty("imagestionProyectCod", NullValueHandling = NullValueHandling.Ignore)]
        public int imagestionProyectCod { get; set; }

        [JsonProperty("imagestionCategoryCod", NullValueHandling = NullValueHandling.Ignore)]
        public int imagestionCategoryCod { get; set; }

        [JsonProperty("imagestionProductId", NullValueHandling = NullValueHandling.Ignore)]
        public int imagestionProductId { get; set; }

        [JsonProperty("serialNumber", NullValueHandling = NullValueHandling.Ignore)]
        public int serialNumber { get; set; }

        [JsonProperty("prestashopCombinationId", NullValueHandling = NullValueHandling.Ignore)]
        public int prestashopCombinationId { get; set; }

        [JsonProperty("prestashopValueId", NullValueHandling = NullValueHandling.Ignore)]
        public int prestashopValueId { get; set; }

        [JsonProperty("product", NullValueHandling = NullValueHandling.Ignore)]
        public Product product { get; set; }

        [JsonProperty("attribute_values", NullValueHandling = NullValueHandling.Ignore)]
        public AttributeValues attribute_values { get; set; }

        [JsonProperty("costs", NullValueHandling = NullValueHandling.Ignore)]
        public Costs costs { get; set; }
    }


}
