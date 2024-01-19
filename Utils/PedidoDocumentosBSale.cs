using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_Integrador_MeLoLLevo.Utils
{

    public class BookType
    {
        public string href { get; set; }
        public string id { get; set; }

    }

    public class DocumentType
    {
        [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
        public string href { get; set; }
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int? id { get; set; }
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string name { get; set; }
        [JsonProperty("initialNumber", NullValueHandling = NullValueHandling.Ignore)]
        public int? initialNumber { get; set; }
        [JsonProperty("codeSii", NullValueHandling = NullValueHandling.Ignore)]
        public string codeSii { get; set; }
        [JsonProperty("isElectronicDocument", NullValueHandling = NullValueHandling.Ignore)]
        public int? isElectronicDocument { get; set; }
        [JsonProperty("breakdownTax", NullValueHandling = NullValueHandling.Ignore)]
        public int? breakdownTax { get; set; }
        [JsonProperty("use", NullValueHandling = NullValueHandling.Ignore)]
        public int? use { get; set; }
        [JsonProperty("isSalesNote", NullValueHandling = NullValueHandling.Ignore)]
        public int? isSalesNote { get; set; }
        [JsonProperty("isExempt", NullValueHandling = NullValueHandling.Ignore)]
        public int? isExempt { get; set; }
        [JsonProperty("restrictsTax", NullValueHandling = NullValueHandling.Ignore)]
        public int? restrictsTax { get; set; }
        [JsonProperty("useClient", NullValueHandling = NullValueHandling.Ignore)]
        public int? useClient { get; set; }
        [JsonProperty("messageBodyFormat")]
        public object messageBodyFormat { get; set; }
        [JsonProperty("thermalPrinter", NullValueHandling = NullValueHandling.Ignore)]
        public int? thermalPrinter { get; set; }
        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public int? state { get; set; }
        [JsonProperty("copyNumber", NullValueHandling = NullValueHandling.Ignore)]
        public int? copyNumber { get; set; }
        [JsonProperty("isCreditNote", NullValueHandling = NullValueHandling.Ignore)]
        public int? isCreditNote { get; set; }
        [JsonProperty("continuedHigh", NullValueHandling = NullValueHandling.Ignore)]
        public int? continuedHigh { get; set; }
        [JsonProperty("ledgerAccount", NullValueHandling = NullValueHandling.Ignore)]
        public string ledgerAccount { get; set; }
        [JsonProperty("ipadPrint", NullValueHandling = NullValueHandling.Ignore)]
        public int? ipadPrint { get; set; }
        [JsonProperty("ipadPrintHigh", NullValueHandling = NullValueHandling.Ignore)]
        public int? ipadPrintHigh { get; set; }

        [JsonProperty("book_type", NullValueHandling = NullValueHandling.Ignore)]
        public BookType book_type { get; set; }

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

    public class PaymentType
    {
        [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
        public string href { get; set; }
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string id { get; set; }

    }

    public class SaleCondition
    {
        [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
        public string href { get; set; }
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string id { get; set; }

    }

    public class Client
    {
        [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
        public string href { get; set; }
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int? id { get; set; }
        [JsonProperty("firstName", NullValueHandling = NullValueHandling.Ignore)]
        public string firstName { get; set; }
        [JsonProperty("lastName", NullValueHandling = NullValueHandling.Ignore)]
        public string lastName { get; set; }
        [JsonProperty("email")]
        public string email { get; set; }
        [JsonProperty("code")]
        public string code { get; set; }
        [JsonProperty("phone")]
        public string phone { get; set; }
        [JsonProperty("company", NullValueHandling = NullValueHandling.Ignore)]
        public string company { get; set; }
        [JsonProperty("note")]
        public string note { get; set; }
        [JsonProperty("facebook")]
        public string facebook { get; set; }
        [JsonProperty("twitter")]
        public string twitter { get; set; }
        [JsonProperty("hasCredit")]
        public string hasCredit { get; set; }
        [JsonProperty("maxCredit", NullValueHandling = NullValueHandling.Ignore)]
        public string maxCredit { get; set; }
        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public int? state { get; set; }
        [JsonProperty("activity", NullValueHandling = NullValueHandling.Ignore)]
        public string activity { get; set; }
        [JsonProperty("city")]
        public string city { get; set; }
        [JsonProperty("municipality")]
        public string municipality { get; set; }
        [JsonProperty("address")]
        public string address { get; set; }
        [JsonProperty("companyOrPerson", NullValueHandling = NullValueHandling.Ignore)]
        public int? companyOrPerson { get; set; }
        [JsonProperty("accumulatePoints", NullValueHandling = NullValueHandling.Ignore)]
        public int? accumulatePoints { get; set; }
        [JsonProperty("points", NullValueHandling = NullValueHandling.Ignore)]
        public double points { get; set; }
        [JsonProperty("pointsUpdated", NullValueHandling = NullValueHandling.Ignore)]
        public string pointsUpdated { get; set; }
        [JsonProperty("sendDte", NullValueHandling = NullValueHandling.Ignore)]
        public int? sendDte { get; set; }
        [JsonProperty("isForeigner")]
        public int? isForeigner { get; set; }
        [JsonProperty("prestashopClienId", NullValueHandling = NullValueHandling.Ignore)]
        public int? prestashopClienId { get; set; }
        [JsonProperty("createdAt", NullValueHandling = NullValueHandling.Ignore)]
        public int? createdAt { get; set; }
        [JsonProperty("updatedAt", NullValueHandling = NullValueHandling.Ignore)]
        public int? updatedAt { get; set; }
        [JsonProperty("contacts", NullValueHandling = NullValueHandling.Ignore)]
        public Contacts contacts { get; set; }
        [JsonProperty("attributes", NullValueHandling = NullValueHandling.Ignore)]
        public Attributes attributes { get; set; }
        [JsonProperty("addresses", NullValueHandling = NullValueHandling.Ignore)]
        public Addresses addresses { get; set; }
        [JsonProperty("payment_type", NullValueHandling = NullValueHandling.Ignore)]
        public PaymentType payment_type { get; set; }
        [JsonProperty("sale_condition", NullValueHandling = NullValueHandling.Ignore)]
        public SaleCondition sale_condition { get; set; }
        //[JsonProperty("price_list", NullValueHandling = NullValueHandling.Ignore)]
        //public Coin PriceList { get; set; }

    }

    public class Office
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
        public int? id { get; set; }
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
        public int? id { get; set; }
        [JsonProperty("lineNumber", NullValueHandling = NullValueHandling.Ignore)]
        public int? lineNumber { get; set; }
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
        public string relatedDetailId { get; set; }

    }

    public class Details
    {
        [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
        public string href { get; set; }
        [JsonProperty("count", NullValueHandling = NullValueHandling.Ignore)]
        public int count { get; set; }
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? limit { get; set; }
        [JsonProperty("offset", NullValueHandling = NullValueHandling.Ignore)]
        public int? offset { get; set; }
        [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
        public List<Item2> items { get; set; }

    }

    public class Sellers
    {
        [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
        public string href { get; set; }

    }

    public class Attributes2
    {
        [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
        public string href { get; set; }

    }

    public class Item
    {
        [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
        public string href { get; set; }
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int? id { get; set; }
        [JsonProperty("emissionDate", NullValueHandling = NullValueHandling.Ignore)]
        public int emissionDate { get; set; }
        [JsonProperty("expirationDate", NullValueHandling = NullValueHandling.Ignore)]
        public int expirationDate { get; set; }
        [JsonProperty("generationDate", NullValueHandling = NullValueHandling.Ignore)]
        public int? generationDate { get; set; }
        [JsonProperty("number", NullValueHandling = NullValueHandling.Ignore)]
        public int? number { get; set; }
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
        [JsonProperty("address")]
        public string address { get; set; }
        [JsonProperty("municipality")]
        public string municipality { get; set; }
        [JsonProperty("city")]
        public string city { get; set; }
        [JsonProperty("urlTimbre")]
        public string urlTimbre { get; set; }
        [JsonProperty("ted")]
        public string ted { get; set; }
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
        public int? state { get; set; }
        [JsonProperty("urlXml", NullValueHandling = NullValueHandling.Ignore)]
        public string urlXml { get; set; }
        [JsonProperty("salesId")]
        public object salesId { get; set; }
        [JsonProperty("informedSii", NullValueHandling = NullValueHandling.Ignore)]
        public int? informedSii { get; set; }
        [JsonProperty("responseMsgSii")]
        public object responseMsgSii { get; set; }
        [JsonProperty("document_type", NullValueHandling = NullValueHandling.Ignore)]
        public DocumentType document_type { get; set; }
        [JsonProperty("client", NullValueHandling = NullValueHandling.Ignore)]
        public Client client { get; set; }
        [JsonProperty("office", NullValueHandling = NullValueHandling.Ignore)]
        public Office office { get; set; }
        [JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
        public User user { get; set; }
        [JsonProperty("coin", NullValueHandling = NullValueHandling.Ignore)]
        public Coin coin { get; set; }
        [JsonProperty("references", NullValueHandling = NullValueHandling.Ignore)]
        public References references { get; set; }
        [JsonProperty("document_taxes", NullValueHandling = NullValueHandling.Ignore)]
        public DocumentTaxes document_taxes { get; set; }
        [JsonProperty("details", NullValueHandling = NullValueHandling.Ignore)]
        public Details details { get; set; }
        [JsonProperty("sellers", NullValueHandling = NullValueHandling.Ignore)]
        public Sellers sellers { get; set; }
        [JsonProperty("attributes", NullValueHandling = NullValueHandling.Ignore)]
        public Attributes2 attributes { get; set; }
        //[JsonProperty("sale_condition", NullValueHandling = NullValueHandling.Ignore)]
        //public Coin SaleCondition { get; set; }

    }

    public class PedidoDocumentosBSale
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
        public List<Item> items { get; set; }
        [JsonProperty("next", NullValueHandling = NullValueHandling.Ignore)]
        public string next { get; set; }

    }

}
