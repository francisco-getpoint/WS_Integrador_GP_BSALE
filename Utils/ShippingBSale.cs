using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_Integrador_GP_BSALE.Utils
{

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Office
        {
            [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
            public string href { get; set; }
        
            [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)] 
            public int id { get; set; }
        
            [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
            public string name { get; set; }
        
            [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
            public string description { get; set; }

            [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
            public string address { get; set; }

            [JsonProperty("latitude", NullValueHandling = NullValueHandling.Ignore)]
            public string latitude { get; set; }

            [JsonProperty("longitude", NullValueHandling = NullValueHandling.Ignore)]
            public string longitude { get; set; }

            [JsonProperty("isVirtual", NullValueHandling = NullValueHandling.Ignore)]
            public int isVirtual { get; set; }

            [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
            public string country { get; set; }

            [JsonProperty("municipality", NullValueHandling = NullValueHandling.Ignore)]
            public string municipality { get; set; }

            [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
            public string city { get; set; }

            [JsonProperty("zipCode", NullValueHandling = NullValueHandling.Ignore)]
            public string zipCode { get; set; }

            [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
            public string email { get; set; }

            [JsonProperty("costCenter", NullValueHandling = NullValueHandling.Ignore)]
            public string costCenter { get; set; }

            [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
            public int state { get; set; }

            [JsonProperty("imagestionCellarId", NullValueHandling = NullValueHandling.Ignore)]
            public int imagestionCellarId { get; set; }

            [JsonProperty("defaultPriceList", NullValueHandling = NullValueHandling.Ignore)]
            public int defaultPriceList { get; set; }
        }

        public class DestinationOffice
        {
            [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
            public string href { get; set; }

            [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
            public string id { get; set; }
        }

        public class User
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

        public class DocumentType
        {
            [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
            public string href { get; set; }

            [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
            public int id { get; set; }

            [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)] 
            public string name { get; set; }

            [JsonProperty("initialNumber", NullValueHandling = NullValueHandling.Ignore)]
            public int initialNumber { get; set; }

            [JsonProperty("codeSii", NullValueHandling = NullValueHandling.Ignore)]
            public string codeSii { get; set; }

            [JsonProperty("isElectronicDocument", NullValueHandling = NullValueHandling.Ignore)]
            public int isElectronicDocument { get; set; }

            [JsonProperty("breakdownTax", NullValueHandling = NullValueHandling.Ignore)]
            public int breakdownTax { get; set; }
        
            [JsonProperty("use", NullValueHandling = NullValueHandling.Ignore)]         
            public int use { get; set; }

            [JsonProperty("isSalesNote", NullValueHandling = NullValueHandling.Ignore)]        
            public int isSalesNote { get; set; }
        
            [JsonProperty("isExempt", NullValueHandling = NullValueHandling.Ignore)] 
            public int isExempt { get; set; }
        
            [JsonProperty("restrictsTax", NullValueHandling = NullValueHandling.Ignore)]
            public int restrictsTax { get; set; }
        
            [JsonProperty("useClient", NullValueHandling = NullValueHandling.Ignore)]
            public int useClient { get; set; }
        
            [JsonProperty("messageBodyFormat", NullValueHandling = NullValueHandling.Ignore)]
            public object messageBodyFormat { get; set; }
        
            [JsonProperty("thermalPrinter", NullValueHandling = NullValueHandling.Ignore)]
            public int thermalPrinter { get; set; }
        
            [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
            public int state { get; set; }
        
            [JsonProperty("copyNumber", NullValueHandling = NullValueHandling.Ignore)]
            public int copyNumber { get; set; }
        
            [JsonProperty("isCreditNote", NullValueHandling = NullValueHandling.Ignore)]
            public int isCreditNote { get; set; }
        
            [JsonProperty("continuedHigh", NullValueHandling = NullValueHandling.Ignore)]
            public int continuedHigh { get; set; }
        
            [JsonProperty("ledgerAccount", NullValueHandling = NullValueHandling.Ignore)]
            public string ledgerAccount { get; set; }
        
            [JsonProperty("ipadPrint", NullValueHandling = NullValueHandling.Ignore)]
            public int ipadPrint { get; set; }
        
            [JsonProperty("ipadPrintHigh", NullValueHandling = NullValueHandling.Ignore)]
            public int ipadPrintHigh { get; set; }
        
            [JsonProperty("restrictClientType", NullValueHandling = NullValueHandling.Ignore)]
            public int restrictClientType { get; set; }
        }

        public class Contacts
        {
            [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
            public string href { get; set; }
        }

        public class Attributes
        {
            [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
            public string href { get; set; }
        }

        public class Addresses
        {
            [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
            public string href { get; set; }
        }

        public class Client
        {
            [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
            public string href { get; set; }

            [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
            public int id { get; set; }

            [JsonProperty("firstName", NullValueHandling = NullValueHandling.Ignore)]
            public string firstName { get; set; }

            [JsonProperty("lastName", NullValueHandling = NullValueHandling.Ignore)]
            public string lastName { get; set; }

            [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
            public string email { get; set; }

            [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
            public string code { get; set; }

            [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
            public string phone { get; set; }

            [JsonProperty("company", NullValueHandling = NullValueHandling.Ignore)]
            public string company { get; set; }

            [JsonProperty("note", NullValueHandling = NullValueHandling.Ignore)]
            public object note { get; set; }

            [JsonProperty("facebook", NullValueHandling = NullValueHandling.Ignore)]
            public object facebook { get; set; }

            [JsonProperty("twitter", NullValueHandling = NullValueHandling.Ignore)]
            public string twitter { get; set; }

            [JsonProperty("hasCredit", NullValueHandling = NullValueHandling.Ignore)]
            public string hasCredit { get; set; }

            [JsonProperty("maxCredit", NullValueHandling = NullValueHandling.Ignore)]
            public double maxCredit { get; set; }

            [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
            public int state { get; set; }

            [JsonProperty("activity", NullValueHandling = NullValueHandling.Ignore)]
            public string activity { get; set; }

            [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
            public string city { get; set; }

            [JsonProperty("municipality", NullValueHandling = NullValueHandling.Ignore)]
            public string municipality { get; set; }

            [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
            public string address { get; set; }

            [JsonProperty("companyOrPerson", NullValueHandling = NullValueHandling.Ignore)]
            public int companyOrPerson { get; set; }

            [JsonProperty("accumulatePoints", NullValueHandling = NullValueHandling.Ignore)]
            public int accumulatePoints { get; set; }

            [JsonProperty("points", NullValueHandling = NullValueHandling.Ignore)]
            public double points { get; set; }

            [JsonProperty("pointsUpdated", NullValueHandling = NullValueHandling.Ignore)]
            public string pointsUpdated { get; set; }

            [JsonProperty("sendDte", NullValueHandling = NullValueHandling.Ignore)]
            public int sendDte { get; set; }

            [JsonProperty("isForeigner", NullValueHandling = NullValueHandling.Ignore)]
            public int isForeigner { get; set; }

            [JsonProperty("prestashopClienId", NullValueHandling = NullValueHandling.Ignore)]
            public int prestashopClienId { get; set; }

            [JsonProperty("createdAt", NullValueHandling = NullValueHandling.Ignore)]
            public int createdAt { get; set; }

            [JsonProperty("updatedAt", NullValueHandling = NullValueHandling.Ignore)]
            public int updatedAt { get; set; }
            public Contacts contacts { get; set; }
            public Attributes attributes { get; set; }
            public Addresses addresses { get; set; }
        }

        public class Coin
        {
            [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
            public string href { get; set; }

            [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
            public string id { get; set; }
        }

        public class References
        {
            [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
            public string href { get; set; }
        }

        public class DocumentTaxes
        {
            [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
            public string href { get; set; }
        }

        public class Variant
        {
            [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
            public string href { get; set; }

            [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
            public int id { get; set; }

            [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
            public string description { get; set; }

            [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
            public string code { get; set; }
        }

        public class Item2
        {
            [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
            public string href { get; set; }

            [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
            public int id { get; set; }

            [JsonProperty("lineNumber", NullValueHandling = NullValueHandling.Ignore)]
            public int lineNumber { get; set; }

            [JsonProperty("quantity", NullValueHandling = NullValueHandling.Ignore)]
            public double quantity { get; set; }

            [JsonProperty("netUnitValue", NullValueHandling = NullValueHandling.Ignore)]
            public double netUnitValue { get; set; }

            [JsonProperty("totalUnitValue", NullValueHandling = NullValueHandling.Ignore)]
            public double totalUnitValue { get; set; }

            [JsonProperty("netAmount", NullValueHandling = NullValueHandling.Ignore)]
            public double netAmount { get; set; }

            [JsonProperty("taxAmount", NullValueHandling = NullValueHandling.Ignore)]
            public double taxAmount { get; set; }

            [JsonProperty("totalAmount", NullValueHandling = NullValueHandling.Ignore)]
            public double totalAmount { get; set; }

            [JsonProperty("netDiscount", NullValueHandling = NullValueHandling.Ignore)]
            public double netDiscount { get; set; }

            [JsonProperty("totalDiscount", NullValueHandling = NullValueHandling.Ignore)]
            public double totalDiscount { get; set; }

            [JsonProperty("variant", NullValueHandling = NullValueHandling.Ignore)]
            public Variant variant { get; set; }

            [JsonProperty("note", NullValueHandling = NullValueHandling.Ignore)]
            public string note { get; set; }

            [JsonProperty("relatedDetailId", NullValueHandling = NullValueHandling.Ignore)]
            public int relatedDetailId { get; set; }

            [JsonProperty("variantStock", NullValueHandling = NullValueHandling.Ignore)]
            public double variantStock { get; set; }

            [JsonProperty("variantCost", NullValueHandling = NullValueHandling.Ignore)]
            public double variantCost { get; set; }

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
            public Office office { get; set; }
            public DestinationOffice destinationOffice { get; set; }
            public User user { get; set; }
            public ShippingType shipping_type { get; set; }
            public Guide guide { get; set; }
            public Details details { get; set; }
        }

        public class Details
        {
            [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
            public string href { get; set; }

            [JsonProperty("count", NullValueHandling = NullValueHandling.Ignore)]
            public int count { get; set; }

            [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
            public int limit { get; set; }

            [JsonProperty("offset", NullValueHandling = NullValueHandling.Ignore)]
            public int offset { get; set; }
            public List<Item2> items { get; set; }
        }

        public class Sellers
        {
            [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
            public string href { get; set; }
        }

        public class Guide
        {
            [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
            public string href { get; set; }

            [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
            public int id { get; set; }

            [JsonProperty("emissionDate", NullValueHandling = NullValueHandling.Ignore)]
            public int emissionDate { get; set; }

            [JsonProperty("expirationDate", NullValueHandling = NullValueHandling.Ignore)]
            public int expirationDate { get; set; }

            [JsonProperty("generationDate", NullValueHandling = NullValueHandling.Ignore)]
            public int generationDate { get; set; }

            [JsonProperty("number", NullValueHandling = NullValueHandling.Ignore)]
            public int number { get; set; }

            [JsonProperty("serialNumber", NullValueHandling = NullValueHandling.Ignore)]
            public object serialNumber { get; set; }

            [JsonProperty("totalAmount", NullValueHandling = NullValueHandling.Ignore)]
            public double totalAmount { get; set; }

            [JsonProperty("netAmount", NullValueHandling = NullValueHandling.Ignore)]
            public double netAmount { get; set; }

            [JsonProperty("taxAmount", NullValueHandling = NullValueHandling.Ignore)]
            public double taxAmount { get; set; }

            [JsonProperty("exemptAmount", NullValueHandling = NullValueHandling.Ignore)]
            public double exemptAmount { get; set; }

            [JsonProperty("notExemptAmount", NullValueHandling = NullValueHandling.Ignore)]
            public double notExemptAmount { get; set; }

            [JsonProperty("exportTotalAmount", NullValueHandling = NullValueHandling.Ignore)]
            public double exportTotalAmount { get; set; }

            [JsonProperty("exportNetAmount", NullValueHandling = NullValueHandling.Ignore)]
            public double exportNetAmount { get; set; }

            [JsonProperty("exportTaxAmount", NullValueHandling = NullValueHandling.Ignore)]
            public double exportTaxAmount { get; set; }

            [JsonProperty("exportExemptAmount", NullValueHandling = NullValueHandling.Ignore)]
            public double exportExemptAmount { get; set; }

            [JsonProperty("commissionRate", NullValueHandling = NullValueHandling.Ignore)]
            public double commissionRate { get; set; }

            [JsonProperty("commissionNetAmount", NullValueHandling = NullValueHandling.Ignore)]
            public double commissionNetAmount { get; set; }

            [JsonProperty("commissionTaxAmount", NullValueHandling = NullValueHandling.Ignore)]
            public double commissionTaxAmount { get; set; }

            [JsonProperty("commissionTotalAmount", NullValueHandling = NullValueHandling.Ignore)]
            public double commissionTotalAmount { get; set; }

            [JsonProperty("percentageTaxWithheld", NullValueHandling = NullValueHandling.Ignore)]
            public double percentageTaxWithheld { get; set; }

            [JsonProperty("purchaseTaxAmount", NullValueHandling = NullValueHandling.Ignore)]
            public double purchaseTaxAmount { get; set; }

            [JsonProperty("purchaseTotalAmount", NullValueHandling = NullValueHandling.Ignore)]
            public double purchaseTotalAmount { get; set; }

            [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
            public string address { get; set; }

            [JsonProperty("municipality", NullValueHandling = NullValueHandling.Ignore)]
            public string municipality { get; set; }

            [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
            public string city { get; set; }

            [JsonProperty("urlTimbre", NullValueHandling = NullValueHandling.Ignore)]
            public string urlTimbre { get; set; }

            [JsonProperty("urlPublicView", NullValueHandling = NullValueHandling.Ignore)]
            public string urlPublicView { get; set; }

            [JsonProperty("urlPdf", NullValueHandling = NullValueHandling.Ignore)]
            public string urlPdf { get; set; }

            [JsonProperty("urlPublicViewOriginal", NullValueHandling = NullValueHandling.Ignore)]
            public string urlPublicViewOriginal { get; set; }

            [JsonProperty("urlPdfOriginal", NullValueHandling = NullValueHandling.Ignore)]
            public string urlPdfOriginal { get; set; }

            [JsonProperty("token", NullValueHandling = NullValueHandling.Ignore)]
            public string token { get; set; }

            [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
            public int state { get; set; }

            [JsonProperty("urlXml", NullValueHandling = NullValueHandling.Ignore)]
            public string urlXml { get; set; }

            [JsonProperty("ted", NullValueHandling = NullValueHandling.Ignore)]
            public string ted { get; set; }

            [JsonProperty("salesId", NullValueHandling = NullValueHandling.Ignore)]
            public object salesId { get; set; }

            [JsonProperty("informedSii", NullValueHandling = NullValueHandling.Ignore)]
            public int informedSii { get; set; }

            [JsonProperty("responseMsgSii", NullValueHandling = NullValueHandling.Ignore)]
            public string responseMsgSii { get; set; }
            public DocumentType document_type { get; set; }
            public Client client { get; set; }
            public Office office { get; set; }
            public User user { get; set; }
            public Coin coin { get; set; }
            public References references { get; set; }
            public DocumentTaxes document_taxes { get; set; }
            public Details details { get; set; }
            public Sellers sellers { get; set; }
            public Attributes attributes { get; set; }
        }

        public class ShippingBSale
        {
            [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
            public string href { get; set; }

            [JsonProperty("count", NullValueHandling = NullValueHandling.Ignore)]
            public int count { get; set; }

            [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
            public int limit { get; set; }

            [JsonProperty("offset", NullValueHandling = NullValueHandling.Ignore)]
            public int offset { get; set; }
        
            public List<Item2> items { get; set; }
        }

    public class DynamicAttributes
    {
        [JsonProperty("_52", NullValueHandling = NullValueHandling.Ignore)]
        public string _52 { get; set; }
    }

    public class ExtrasUserData
    {
        [JsonProperty("user_rut", NullValueHandling = NullValueHandling.Ignore)]
        public string user_rut { get; set; }
        [JsonProperty("razon_social", NullValueHandling = NullValueHandling.Ignore)]
        public string razon_social { get; set; }
        [JsonProperty("giro_cliente", NullValueHandling = NullValueHandling.Ignore)]
        public string giro_cliente { get; set; }
        [JsonProperty("direccion", NullValueHandling = NullValueHandling.Ignore)]
        public string direccion { get; set; }
        [JsonProperty("ciudad", NullValueHandling = NullValueHandling.Ignore)]
        public string ciudad { get; set; }
        [JsonProperty("comuna", NullValueHandling = NullValueHandling.Ignore)]
        public string comuna { get; set; }
    }

    public class Datum
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int id { get; set; }

        [JsonProperty("token", NullValueHandling = NullValueHandling.Ignore)]
        public string token { get; set; }

        [JsonProperty("clientCode", NullValueHandling = NullValueHandling.Ignore)]
        public string clientCode { get; set; }

        [JsonProperty("clientName", NullValueHandling = NullValueHandling.Ignore)]
        public string clientName { get; set; }

        [JsonProperty("clientLastName", NullValueHandling = NullValueHandling.Ignore)]
        public string clientLastName { get; set; }

        [JsonProperty("clientEmail", NullValueHandling = NullValueHandling.Ignore)]
        public string clientEmail { get; set; }
        [JsonProperty("clientPhone", NullValueHandling = NullValueHandling.Ignore)]
        public string clientPhone { get; set; }
        [JsonProperty("id_tipo_documento_tributario", NullValueHandling = NullValueHandling.Ignore)]
        public int id_tipo_documento_tributario { get; set; }

        [JsonProperty("clientCountry", NullValueHandling = NullValueHandling.Ignore)]
        public string clientCountry { get; set; }

        [JsonProperty("clientState", NullValueHandling = NullValueHandling.Ignore)]
        public string clientState { get; set; }

        [JsonProperty("dynamicAttributes", NullValueHandling = NullValueHandling.Ignore)]
        public DynamicAttributes dynamicAttributes { get; set; }

        [JsonProperty("extrasUserData", NullValueHandling = NullValueHandling.Ignore)]
        public ExtrasUserData extrasUserData { get; set; }

        [JsonProperty("clientStreet", NullValueHandling = NullValueHandling.Ignore)]
        public string clientStreet { get; set; }

        [JsonProperty("clientCityZone", NullValueHandling = NullValueHandling.Ignore)]
        public string clientCityZone { get; set; }

        [JsonProperty("clientPostcode", NullValueHandling = NullValueHandling.Ignore)]
        public string clientPostcode { get; set; }

        [JsonProperty("clientBuildingNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string clientBuildingNumber { get; set; }
        [JsonProperty("cartId", NullValueHandling = NullValueHandling.Ignore)]
        public int cartId { get; set; }
        public List<string> cartDetails { get; set; }

        [JsonProperty("spcId", NullValueHandling = NullValueHandling.Ignore)]
        public int spcId { get; set; }

        [JsonProperty("ptId", NullValueHandling = NullValueHandling.Ignore)]
        public int ptId { get; set; }

        [JsonProperty("createAt", NullValueHandling = NullValueHandling.Ignore)]
        public int createAt { get; set; }
        [JsonProperty("shippingCost", NullValueHandling = NullValueHandling.Ignore)]
        public decimal shippingCost { get; set; }
        [JsonProperty("isMafs", NullValueHandling = NullValueHandling.Ignore)]
        public int isMafs { get; set; }
        [JsonProperty("discountCost", NullValueHandling = NullValueHandling.Ignore)]
        public decimal discountCost { get; set; }
        [JsonProperty("active", NullValueHandling = NullValueHandling.Ignore)]
        public int active { get; set; }
        [JsonProperty("shippingComment", NullValueHandling = NullValueHandling.Ignore)]
        public string shippingComment { get; set; }
        [JsonProperty("totalCart", NullValueHandling = NullValueHandling.Ignore)]
        public decimal totalCart { get; set; }

        [JsonProperty("pickStoreId", NullValueHandling = NullValueHandling.Ignore)]
        public int pickStoreId { get; set; }
        [JsonProperty("pickName", NullValueHandling = NullValueHandling.Ignore)]
        public string pickName { get; set; }
        [JsonProperty("pickCode", NullValueHandling = NullValueHandling.Ignore)]
        public string pickCode { get; set; }
        [JsonProperty("id_venta_documento_tributario", NullValueHandling = NullValueHandling.Ignore)]
        public int id_venta_documento_tributario { get; set; }
        [JsonProperty("documentNumber", NullValueHandling = NullValueHandling.Ignore)]
        public int documentNumber { get; set; }
        [JsonProperty("documentToken", NullValueHandling = NullValueHandling.Ignore)]
        public string documentToken { get; set; }
        [JsonProperty("storeId", NullValueHandling = NullValueHandling.Ignore)]
        public int storeId { get; set; }
        [JsonProperty("marketId", NullValueHandling = NullValueHandling.Ignore)]
        public int marketId { get; set; }
        [JsonProperty("isService", NullValueHandling = NullValueHandling.Ignore)]
        public int isService { get; set; }
        [JsonProperty("withdrawStore", NullValueHandling = NullValueHandling.Ignore)]
        public int withdrawStore { get; set; }
        [JsonProperty("payProcess", NullValueHandling = NullValueHandling.Ignore)]
        public string payProcess { get; set; }
        [JsonProperty("payResponse", NullValueHandling = NullValueHandling.Ignore)]
        public string payResponse { get; set; }

        [JsonProperty("stName", NullValueHandling = NullValueHandling.Ignore)]
        public string stName { get; set; }
        [JsonProperty("total", NullValueHandling = NullValueHandling.Ignore)]
        public decimal total { get; set; }
        [JsonProperty("clientId", NullValueHandling = NullValueHandling.Ignore)]
        public int clientId { get; set; }

        [JsonProperty("userId", NullValueHandling = NullValueHandling.Ignore)]
        public int userId { get; set; }
        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string url { get; set; }
        [JsonProperty("IntegrationDetail", NullValueHandling = NullValueHandling.Ignore)]
        public IntegrationDetail integrationDetail { get; set; }
    }

    public class IntegrationDetail
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string id { get; set; }
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string type { get; set; }
        [JsonProperty("pack_id", NullValueHandling = NullValueHandling.Ignore)]
        public string pack_id { get; set; }
        [JsonProperty("resource", NullValueHandling = NullValueHandling.Ignore)]
        public string resource { get; set; }
        [JsonProperty("shipping_id", NullValueHandling = NullValueHandling.Ignore)]
        public string shipping_id { get; set; }
        [JsonProperty("shipping_mode", NullValueHandling = NullValueHandling.Ignore)]
        public string shipping_mode { get; set; }
        [JsonProperty("shipping_mode_str", NullValueHandling = NullValueHandling.Ignore)]
        public string shipping_mode_str { get; set; }
    }

    public class TaxDocument
    {

        public int code { get; set; }
        public string href { get; set; }
        public int count { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public List<Datum> data { get; set; }
    }

    public class DocumentAttributteItem
    {
        [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
        public string href { get; set; }
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int id { get; set; }
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string name { get; set; }
        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public string value { get; set; }
    }

    public class DocumentAttributte
    {
        [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
        public string href { get; set; }
        [JsonProperty("count", NullValueHandling = NullValueHandling.Ignore)]
        public int count { get; set; }
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public int limit { get; set; }
        [JsonProperty("offset", NullValueHandling = NullValueHandling.Ignore)]
        public int offset { get; set; }
        [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
        public List<DocumentAttributteItem> items { get; set; }
    }
}
