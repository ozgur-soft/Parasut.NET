using System.Net.Http.Headers;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Parasut {
    public interface IParasut {
        void SetCompanyId(string companyid);
        void SetClientId(string clientid);
        void SetClientSecret(string clientsecret);
        void SetUsername(string username);
        void SetPassword(string password);
        void Authentication();
        Parasut.Response.SalesInvoice.SalesInvoiceData CreateSalesInvoice(Parasut.Request.SalesInvoice data);
        Parasut.Response.SalesInvoice.SalesInvoiceData ShowSalesInvoice(string id);
        Parasut.Response.SalesInvoice.SalesInvoiceData DeleteSalesInvoice(string id);
        Parasut.Response.SalesInvoice.SalesInvoiceData RecoverSalesInvoice(string id);
        Parasut.Response.SalesInvoice.SalesInvoiceData ArchiveSalesInvoice(string id);
        Parasut.Response.SalesInvoice.SalesInvoiceData UnarchiveSalesInvoice(string id);
        Parasut.Response.SalesInvoice.SalesInvoiceData CancelSalesInvoice(string id);
        Parasut.Response.SalesInvoice.SalesInvoiceData ConvertSalesInvoice(string id);
        Parasut.Response.EArchive.EArchiveData CreateEArchive(Parasut.Request.EArchive data);
        Parasut.Response.EInvoice.EInvoiceData CreateEInvoice(Parasut.Request.EInvoice data);
        Parasut.Response.EArchive.EArchiveData ShowEArchive(string id);
        Parasut.Response.EInvoice.EInvoiceData ShowEInvoice(string id);
        Parasut.Response.EArchivePDF.EArchivePDFData ShowEArchivePDF(string id);
        Parasut.Response.EInvoicePDF.EInvoicePDFData ShowEInvoicePDF(string id);
        List<Parasut.Response.EInvoiceInboxes.EInvoiceInboxesData> ListEInvoiceInboxes(string vkn);
    }
    public class Parasut : IParasut {
        private string Endpoint { get; set; }
        private string CompanyId { get; set; }
        private string ClientId { get; set; }
        private string ClientSecret { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }
        private string Token { get; set; }
        public Parasut() {
            Endpoint = "https://api.parasut.com/v4/";
        }
        public class Request {
            public class Authentication {
                [JsonPropertyName("client_id")]
                public string ClientId { init; get; }
                [JsonPropertyName("client_secret")]
                public string ClientSecret { init; get; }
                [JsonPropertyName("username")]
                public string Username { init; get; }
                [JsonPropertyName("password")]
                public string Password { init; get; }
                [JsonPropertyName("grant_type")]
                public string GrantType { init; get; }
                [JsonPropertyName("redirect_uri")]
                public string RedirectURI { init; get; }
            }
            public class SalesInvoice {
                [JsonPropertyName("data")]
                public SalesInvoiceData Data { init; get; }
                public class SalesInvoiceData {
                    [JsonPropertyName("id")]
                    public string Id { init; get; }
                    [JsonPropertyName("type")]
                    public string Type { init; get; }
                    [JsonPropertyName("attributes")]
                    public Attributes Attributes { init; get; }
                    [JsonPropertyName("relationships")]
                    public Relationships Relationships { init; get; }
                }
                public class Attributes {
                    [JsonPropertyName("invoice_id")]
                    public int? InvoiceId { init; get; }
                    [JsonPropertyName("invoice_series")]
                    public string InvoiceSeries { init; get; }
                    [JsonPropertyName("item_type")]
                    public string ItemType { init; get; }
                    [JsonPropertyName("description")]
                    public string Description { init; get; }
                    [JsonPropertyName("issue_date")]
                    public DateTime? IssueDate { init; get; }
                    [JsonPropertyName("due_date")]
                    public DateTime? DueDate { init; get; }
                    [JsonPropertyName("order_date")]
                    public DateTime? OrderDate { init; get; }
                    [JsonPropertyName("order_no")]
                    public string OrderNo { init; get; }
                    [JsonPropertyName("currency")]
                    public string Currency { init; get; }
                    [JsonPropertyName("exchange_rate")]
                    public string ExchangeRate { init; get; }
                    [JsonPropertyName("withholding_rate")]
                    public string WithholdingRate { init; get; }
                    [JsonPropertyName("vat_withholding_rate")]
                    public string VatWithholdingRate { init; get; }
                    [JsonPropertyName("invoice_discount_type")]
                    public string InvoiceDiscountType { init; get; }
                    [JsonPropertyName("invoice_discount")]
                    public string InvoiceDiscount { init; get; }
                    [JsonPropertyName("billing_address")]
                    public string BillingAddress { init; get; }
                    [JsonPropertyName("billing_phone")]
                    public string BillingPhone { init; get; }
                    [JsonPropertyName("billing_fax")]
                    public string BillingFax { init; get; }
                    [JsonPropertyName("tax_office")]
                    public string TaxOffice { init; get; }
                    [JsonPropertyName("tax_number")]
                    public string TaxNumber { init; get; }
                    [JsonPropertyName("country")]
                    public string Country { init; get; }
                    [JsonPropertyName("city")]
                    public string City { init; get; }
                    [JsonPropertyName("district")]
                    public string District { init; get; }
                    [JsonPropertyName("payment_account_id")]
                    public string PaymentAccountID { init; get; }
                    [JsonPropertyName("payment_date")]
                    public string PaymentDate { init; get; }
                    [JsonPropertyName("payment_description")]
                    public string PaymentDescription { init; get; }
                    [JsonPropertyName("shipment_addres")]
                    public string ShipmentAddres { init; get; }
                    [JsonPropertyName("shipment_included")]
                    public bool? ShipmentIncluded { init; get; }
                    [JsonPropertyName("cash_sale")]
                    public bool? CashSale { init; get; }
                    [JsonPropertyName("is_abroad")]
                    public bool? IsAbroad { init; get; }
                }
                public class Relationships {
                    [JsonPropertyName("category")]
                    public Category Category { get; set; }
                    [JsonPropertyName("contact")]
                    public Contact Contact { get; set; }
                    [JsonPropertyName("details")]
                    public object Details { get; set; }
                    [JsonPropertyName("tags")]
                    public Tag[] Tags { get; set; }
                    [JsonPropertyName("sales_offer")]
                    public SalesOffer SalesOffer { get; set; }
                }
                public class Category {
                    [JsonPropertyName("data")]
                    public CategoryData Data { init; get; }
                    public class CategoryData {
                        [JsonPropertyName("id")]
                        public string Id { init; get; }
                        [JsonPropertyName("type")]
                        public string Type { init; get; }
                    }
                }
                public class Contact {
                    [JsonPropertyName("data")]
                    public ContactData Data { init; get; }
                    public class ContactData {
                        [JsonPropertyName("id")]
                        public string Id { init; get; }
                        [JsonPropertyName("type")]
                        public string Type { init; get; }
                    }
                }
                public class Tag {
                    [JsonPropertyName("data")]
                    public TagData Data { init; get; }
                    public class TagData {
                        [JsonPropertyName("id")]
                        public string Id { init; get; }
                        [JsonPropertyName("type")]
                        public string Type { init; get; }
                    }
                }
                public class SalesOffer {
                    [JsonPropertyName("data")]
                    public SalesOfferData Data { init; get; }
                    public class SalesOfferData {
                        [JsonPropertyName("id")]
                        public string Id { init; get; }
                        [JsonPropertyName("type")]
                        public string Type { init; get; }
                    }
                }
            }
            public class EArchive {
                [JsonPropertyName("data")]
                public EArchiveData Data { init; get; }
                public class EArchiveData {
                    [JsonPropertyName("id")]
                    public string Id { init; get; }
                    [JsonPropertyName("type")]
                    public string Type { init; get; }
                    [JsonPropertyName("attributes")]
                    public Attributes Attributes { init; get; }
                    [JsonPropertyName("relationships")]
                    public Relationships Relationships { init; get; }
                }
                public class Attributes {
                    [JsonPropertyName("vat_withholding_code")]
                    public string VatWithholdingCode { init; get; }
                    [JsonPropertyName("vat_exemption_reason_code")]
                    public string VatExemptionReasonCode { init; get; }
                    [JsonPropertyName("vat_exemption_reason")]
                    public string VatExemptionReason { init; get; }
                    [JsonPropertyName("note")]
                    public string Note { init; get; }
                    [JsonPropertyName("excise_duty_codes")]
                    public ExciseDutyCode[] ExciseDutyCodes { init; get; }
                    [JsonPropertyName("internet_sale")]
                    public InternetSaleData InternetSale { init; get; }
                    [JsonPropertyName("shipment")]
                    public ShipmentData Shipment { init; get; }
                    public class ExciseDutyCode {
                        [JsonPropertyName("product")]
                        public int? Product { init; get; }
                        [JsonPropertyName("sales_excise_duty_code")]
                        public string SalesExciseDutyCode { init; get; }
                    }
                    public class InternetSaleData {
                        [JsonPropertyName("url")]
                        public string Url { init; get; }
                        [JsonPropertyName("payment_type")]
                        public string PaymentType { init; get; }
                        [JsonPropertyName("payment_platform")]
                        public string PaymentPlatform { init; get; }
                        [JsonPropertyName("payment_date")]
                        public string PaymentDate { init; get; }
                    }
                    public class ShipmentData {
                        [JsonPropertyName("title")]
                        public string Title { init; get; }
                        [JsonPropertyName("name")]
                        public string Name { init; get; }
                        [JsonPropertyName("vkn")]
                        public string VKN { init; get; }
                        [JsonPropertyName("tckn")]
                        public string TCKN { init; get; }
                        [JsonPropertyName("date")]
                        public string Date { init; get; }
                    }
                }
                public class Relationships {
                    [JsonPropertyName("sales_invoice")]
                    public SalesInvoice SalesInvoice { get; set; }
                }
                public class SalesInvoice {
                    [JsonPropertyName("data")]
                    public SalesInvoiceData Data { init; get; }
                    public class SalesInvoiceData {
                        [JsonPropertyName("id")]
                        public string Id { init; get; }
                        [JsonPropertyName("type")]
                        public string Type { init; get; }
                    }
                }
            }
            public class EInvoice {
                [JsonPropertyName("data")]
                public EInvoiceData Data { init; get; }
                public class EInvoiceData {
                    [JsonPropertyName("id")]
                    public string Id { init; get; }
                    [JsonPropertyName("type")]
                    public string Type { init; get; }
                    [JsonPropertyName("attributes")]
                    public Attributes Attributes { init; get; }
                    [JsonPropertyName("relationships")]
                    public Relationships Relationships { init; get; }
                }
                public class Attributes {
                    [JsonPropertyName("vat_withholding_code")]
                    public string VatWithholdingCode { init; get; }
                    [JsonPropertyName("vat_exemption_reason_code")]
                    public string VatExemptionReasonCode { init; get; }
                    [JsonPropertyName("vat_exemption_reason")]
                    public string VatExemptionReason { init; get; }
                    [JsonPropertyName("note")]
                    public string Note { init; get; }
                    [JsonPropertyName("excise_duty_codes")]
                    public ExciseDutyCode[] ExciseDutyCodes { init; get; }
                    [JsonPropertyName("scenario")]
                    public string Scenario { init; get; }
                    [JsonPropertyName("to")]
                    public string To { init; get; }
                    [JsonPropertyName("custom_requirement_params")]
                    public CustomRequirementParam CustomRequirementParams { init; get; }
                    public class ExciseDutyCode {
                        [JsonPropertyName("product")]
                        public int? Product { init; get; }
                        [JsonPropertyName("sales_excise_duty_code")]
                        public string SalesExciseDutyCode { init; get; }
                    }
                    public class CustomRequirementParam {
                        [JsonPropertyName("integration")]
                        public IntegrationData Integration { init; get; }
                        public class IntegrationData {
                            [JsonPropertyName("data")]
                            public string Data { init; get; }
                        }
                    }
                }
                public class Relationships {
                    [JsonPropertyName("invoice")]
                    public Invoice Invoice { get; set; }
                }
                public class Invoice {
                    [JsonPropertyName("data")]
                    public InvoiceData Data { init; get; }
                    public class InvoiceData {
                        [JsonPropertyName("id")]
                        public string Id { init; get; }
                        [JsonPropertyName("type")]
                        public string Type { init; get; }
                    }
                }
            }
            public class EArchivePDF {
                [JsonPropertyName("data")]
                public EArchivePDFData Data { init; get; }
                public class EArchivePDFData {
                    [JsonPropertyName("id")]
                    public string Id { init; get; }
                    [JsonPropertyName("type")]
                    public string Type { init; get; }
                }
            }
            public class EInvoicePDF {
                [JsonPropertyName("data")]
                public EInvoicePDFData Data { init; get; }
                public class EInvoicePDFData {
                    [JsonPropertyName("id")]
                    public string Id { init; get; }
                    [JsonPropertyName("type")]
                    public string Type { init; get; }
                }
            }
            public class EInvoiceInboxes {
                [JsonPropertyName("data")]
                public EInvoiceInboxesData Data { init; get; }
                public class EInvoiceInboxesData {
                    [JsonPropertyName("id")]
                    public string Id { init; get; }
                    [JsonPropertyName("type")]
                    public string Type { init; get; }
                    [JsonPropertyName("attributes")]
                    public Attributes Attributes { init; get; }
                }
                public class Attributes {
                    [JsonPropertyName("vkn")]
                    public string VKN { init; get; }
                }
            }
        }
        public class Response {
            public class Authentication {
                [JsonPropertyName("token_type")]
                public string TokenType { init; get; }
                [JsonPropertyName("access_token")]
                public string AccessToken { init; get; }
                [JsonPropertyName("refresh_token")]
                public string RefreshToken { init; get; }
                [JsonPropertyName("expires_in")]
                public int? ExpiresIn { init; get; }
                [JsonPropertyName("created_at")]
                public long CreatedAt { init; get; }
                [JsonPropertyName("scope")]
                public string Scope { init; get; }
            }
            public class SalesInvoice {
                [JsonPropertyName("data")]
                public SalesInvoiceData Data { init; get; }
                public class SalesInvoiceData {
                    [JsonPropertyName("id")]
                    public string Id { init; get; }
                    [JsonPropertyName("type")]
                    public string Type { init; get; }
                    [JsonPropertyName("attributes")]
                    public Attributes Attributes { init; get; }
                    [JsonPropertyName("relationships")]
                    public Relationships Relationships { init; get; }
                }
                public class Attributes {
                    [JsonPropertyName("invoice_id")]
                    public int? InvoiceId { init; get; }
                    [JsonPropertyName("invoice_no")]
                    public string InvoiceNo { init; get; }
                    [JsonPropertyName("invoice_series")]
                    public string InvoiceSeries { init; get; }
                    [JsonPropertyName("net_total")]
                    public string NetTotal { init; get; }
                    [JsonPropertyName("gross_total")]
                    public string GrossTotal { init; get; }
                    [JsonPropertyName("total_excise_duty")]
                    public string TotalExciseDuty { init; get; }
                    [JsonPropertyName("total_communications_tax")]
                    public string TotalCommunicationsTax { init; get; }
                    [JsonPropertyName("total_vat")]
                    public string TotalVat { init; get; }
                    [JsonPropertyName("withholding")]
                    public string Withholding { init; get; }
                    [JsonPropertyName("vat_withholding")]
                    public string VatWithholding { init; get; }
                    [JsonPropertyName("withholding_rate")]
                    public string WithholdingRate { init; get; }
                    [JsonPropertyName("vat_withholding_rate")]
                    public string VatWithholdingRate { init; get; }
                    [JsonPropertyName("total_discount")]
                    public string TotalDiscount { init; get; }
                    [JsonPropertyName("total_invoice_discount")]
                    public string TotalInvoiceDiscount { init; get; }
                    [JsonPropertyName("before_taxes_total")]
                    public string BeforeTaxesTotal { init; get; }
                    [JsonPropertyName("remaining")]
                    public string Remaining { init; get; }
                    [JsonPropertyName("remaining_in_trl")]
                    public string RemainingInTrl { init; get; }
                    [JsonPropertyName("created_at")]
                    public string CreatedAt { init; get; }
                    [JsonPropertyName("updated_at")]
                    public string UpdatedAt { init; get; }
                    [JsonPropertyName("item_type")]
                    public string ItemType { init; get; }
                    [JsonPropertyName("description")]
                    public string Description { init; get; }
                    [JsonPropertyName("issue_date")]
                    public DateTime? IssueDate { init; get; }
                    [JsonPropertyName("due_date")]
                    public DateTime? DueDate { init; get; }
                    [JsonPropertyName("order_date")]
                    public DateTime? OrderDate { init; get; }
                    [JsonPropertyName("order_no")]
                    public string OrderNo { init; get; }
                    [JsonPropertyName("currency")]
                    public string Currency { init; get; }
                    [JsonPropertyName("exchange_rate")]
                    public string ExchangeRate { init; get; }
                    [JsonPropertyName("invoice_discount_type")]
                    public string InvoiceDiscountType { init; get; }
                    [JsonPropertyName("invoice_discount")]
                    public string InvoiceDiscount { init; get; }
                    [JsonPropertyName("billing_address")]
                    public string BillingAddress { init; get; }
                    [JsonPropertyName("billing_phone")]
                    public string BillingPhone { init; get; }
                    [JsonPropertyName("billing_fax")]
                    public string BillingFax { init; get; }
                    [JsonPropertyName("tax_office")]
                    public string TaxOffice { init; get; }
                    [JsonPropertyName("tax_number")]
                    public string TaxNumber { init; get; }
                    [JsonPropertyName("country")]
                    public string Country { init; get; }
                    [JsonPropertyName("city")]
                    public string City { init; get; }
                    [JsonPropertyName("district")]
                    public string District { init; get; }
                    [JsonPropertyName("payment_account_id")]
                    public string PaymentAccountID { init; get; }
                    [JsonPropertyName("payment_date")]
                    public string PaymentDate { init; get; }
                    [JsonPropertyName("payment_description")]
                    public string PaymentDescription { init; get; }
                    [JsonPropertyName("payment_status")]
                    public string PaymentStatus { init; get; }
                    [JsonPropertyName("shipment_addres")]
                    public string ShipmentAddres { init; get; }
                    [JsonPropertyName("shipment_included")]
                    public bool? ShipmentIncluded { init; get; }
                    [JsonPropertyName("cash_sale")]
                    public bool? CashSale { init; get; }
                    [JsonPropertyName("is_abroad")]
                    public bool? IsAbroad { init; get; }
                    [JsonPropertyName("archived")]
                    public bool? Archived { init; get; }
                }
                public class Relationships {
                    [JsonPropertyName("category")]
                    public Category Category { get; set; }
                    [JsonPropertyName("contact")]
                    public Contact Contact { get; set; }
                    [JsonPropertyName("details")]
                    public Detail[] Details { get; set; }
                    [JsonPropertyName("payments")]
                    public Payment[] Payments { get; set; }
                    [JsonPropertyName("tags")]
                    public Tag[] Tags { get; set; }
                    [JsonPropertyName("sales_offer")]
                    public SalesOffer SalesOffer { get; set; }
                    [JsonPropertyName("sharings")]
                    public Sharing[] Sharings { get; set; }
                    [JsonPropertyName("recurrence_plan")]
                    public RecurrencePlan RecurrencePlan { get; set; }
                    [JsonPropertyName("active_e_document")]
                    public ActiveEDocument ActiveEDocument { get; set; }
                }
                public class Category {
                    [JsonPropertyName("data")]
                    public CategoryData Data { init; get; }
                    public class CategoryData {
                        [JsonPropertyName("id")]
                        public string Id { init; get; }
                        [JsonPropertyName("type")]
                        public string Type { init; get; }
                    }
                }
                public class Contact {
                    [JsonPropertyName("data")]
                    public ContactData Data { init; get; }
                    public class ContactData {
                        [JsonPropertyName("id")]
                        public string Id { init; get; }
                        [JsonPropertyName("type")]
                        public string Type { init; get; }
                    }
                }
                public class Detail {
                    [JsonPropertyName("data")]
                    public DetailData Data { init; get; }
                    public class DetailData {
                        [JsonPropertyName("id")]
                        public string Id { init; get; }
                        [JsonPropertyName("type")]
                        public string Type { init; get; }
                    }
                }
                public class Payment {
                    [JsonPropertyName("data")]
                    public PaymentData Data { init; get; }
                    public class PaymentData {
                        [JsonPropertyName("id")]
                        public string Id { init; get; }
                        [JsonPropertyName("type")]
                        public string Type { init; get; }
                    }
                }
                public class Tag {
                    [JsonPropertyName("data")]
                    public TagData Data { init; get; }
                    public class TagData {
                        [JsonPropertyName("id")]
                        public string Id { init; get; }
                        [JsonPropertyName("type")]
                        public string Type { init; get; }
                    }
                }
                public class SalesOffer {
                    [JsonPropertyName("data")]
                    public SalesOfferData Data { init; get; }
                    public class SalesOfferData {
                        [JsonPropertyName("id")]
                        public string Id { init; get; }
                        [JsonPropertyName("type")]
                        public string Type { init; get; }
                    }
                }
                public class Sharing {
                    [JsonPropertyName("data")]
                    public SharingData Data { init; get; }
                    public class SharingData {
                        [JsonPropertyName("id")]
                        public string Id { init; get; }
                        [JsonPropertyName("type")]
                        public string Type { init; get; }
                    }
                }
                public class RecurrencePlan {
                    [JsonPropertyName("data")]
                    public RecurrencePlanData Data { init; get; }
                    public class RecurrencePlanData {
                        [JsonPropertyName("id")]
                        public string Id { init; get; }
                        [JsonPropertyName("type")]
                        public string Type { init; get; }
                    }
                }
                public class ActiveEDocument {
                    [JsonPropertyName("data")]
                    public ActiveEDocumentData Data { init; get; }
                    public class ActiveEDocumentData {
                        [JsonPropertyName("id")]
                        public string Id { init; get; }
                        [JsonPropertyName("type")]
                        public string Type { init; get; }
                    }
                }
            }
            public class EArchive {
                [JsonPropertyName("data")]
                public EArchiveData Data { init; get; }
                public class EArchiveData {
                    [JsonPropertyName("id")]
                    public string Id { init; get; }
                    [JsonPropertyName("type")]
                    public string Type { init; get; }
                    [JsonPropertyName("attributes")]
                    public Attributes Attributes { init; get; }
                    [JsonPropertyName("relationships")]
                    public Relationships Relationships { init; get; }
                }
                public class Attributes {
                    [JsonPropertyName("uuid")]
                    public string UUID { init; get; }
                    [JsonPropertyName("vkn")]
                    public string VKN { init; get; }
                    [JsonPropertyName("invoice_number")]
                    public string InvoiceNumber { init; get; }
                    [JsonPropertyName("note")]
                    public string Note { init; get; }
                    [JsonPropertyName("is_printed")]
                    public bool? IsPrinted { init; get; }
                    [JsonPropertyName("status")]
                    public string Status { init; get; }
                    [JsonPropertyName("printed_at")]
                    public string PrintedAt { init; get; }
                    [JsonPropertyName("cancellable_until")]
                    public string CancellableUntil { init; get; }
                    [JsonPropertyName("is_signed")]
                    public bool? IsSigned { init; get; }
                    [JsonPropertyName("created_at")]
                    public string CreatedAt { init; get; }
                    [JsonPropertyName("updated_at")]
                    public string UpdatedAt { init; get; }
                }
                public class Relationships {
                    [JsonPropertyName("sales_invoice")]
                    public SalesInvoice SalesInvoice { get; set; }
                }
                public class SalesInvoice {
                    [JsonPropertyName("data")]
                    public SalesInvoiceData Data { init; get; }
                    public class SalesInvoiceData {
                        [JsonPropertyName("id")]
                        public string Id { init; get; }
                        [JsonPropertyName("type")]
                        public string Type { init; get; }
                    }
                }
            }
            public class EInvoice {
                [JsonPropertyName("data")]
                public EInvoiceData Data { init; get; }
                public class EInvoiceData {
                    [JsonPropertyName("id")]
                    public string Id { init; get; }
                    [JsonPropertyName("type")]
                    public string Type { init; get; }
                    [JsonPropertyName("attributes")]
                    public Attributes Attributes { init; get; }
                    [JsonPropertyName("relationships")]
                    public Relationships Relationships { init; get; }
                }
                public class Attributes {
                    [JsonPropertyName("external_id")]
                    public string ExternalId { init; get; }
                    [JsonPropertyName("uuid")]
                    public string UUID { init; get; }
                    [JsonPropertyName("env_uuid")]
                    public string EnvUUID { init; get; }
                    [JsonPropertyName("from_address")]
                    public string FromAddress { init; get; }
                    [JsonPropertyName("from_vkn")]
                    public string FromVKN { init; get; }
                    [JsonPropertyName("to_address")]
                    public string ToAddress { init; get; }
                    [JsonPropertyName("to_vkn")]
                    public string ToVKN { init; get; }
                    [JsonPropertyName("direction")]
                    public string Direction { init; get; }
                    [JsonPropertyName("note")]
                    public string Note { init; get; }
                    [JsonPropertyName("response_type")]
                    public string ResponseType { init; get; }
                    [JsonPropertyName("contact_name")]
                    public string ContactName { init; get; }
                    [JsonPropertyName("scenario")]
                    public string Scenario { init; get; }
                    [JsonPropertyName("status")]
                    public string Status { init; get; }
                    [JsonPropertyName("gtb_ref_no")]
                    public string GtbRefNo { init; get; }
                    [JsonPropertyName("gtb_registration_no")]
                    public string GtbRegistrationNo { init; get; }
                    [JsonPropertyName("gtb_export_date")]
                    public string GtbExportDate { init; get; }
                    [JsonPropertyName("response_note")]
                    public string ResponseNote { init; get; }
                    [JsonPropertyName("issue_date")]
                    public string IssueDate { init; get; }
                    [JsonPropertyName("is_expired")]
                    public bool? IsExpired { init; get; }
                    [JsonPropertyName("is_answerable")]
                    public bool? IsAnswerable { init; get; }
                    [JsonPropertyName("net_total")]
                    public string NetTotal { init; get; }
                    [JsonPropertyName("currency")]
                    public string Currency { init; get; }
                    [JsonPropertyName("item_type")]
                    public string ItemType { init; get; }
                    [JsonPropertyName("created_at")]
                    public string CreatedAt { init; get; }
                    [JsonPropertyName("updated_at")]
                    public string UpdatedAt { init; get; }
                }
                public class Relationships {
                    [JsonPropertyName("invoice")]
                    public Invoice Invoice { get; set; }
                }
                public class Invoice {
                    [JsonPropertyName("data")]
                    public InvoiceData Data { init; get; }
                    public class InvoiceData {
                        [JsonPropertyName("id")]
                        public string Id { init; get; }
                        [JsonPropertyName("type")]
                        public string Type { init; get; }
                    }
                }
            }
            public class EArchivePDF {
                [JsonPropertyName("data")]
                public EArchivePDFData Data { init; get; }
                public class EArchivePDFData {
                    [JsonPropertyName("id")]
                    public string Id { init; get; }
                    [JsonPropertyName("type")]
                    public string Type { init; get; }
                    [JsonPropertyName("attributes")]
                    public Attributes Attributes { init; get; }
                }
                public class Attributes {
                    [JsonPropertyName("url")]
                    public string Url { init; get; }
                    [JsonPropertyName("expires_at")]
                    public string ExpiresAt { init; get; }
                }
            }
            public class EInvoicePDF {
                [JsonPropertyName("data")]
                public EInvoicePDFData Data { init; get; }
                public class EInvoicePDFData {
                    [JsonPropertyName("id")]
                    public string Id { init; get; }
                    [JsonPropertyName("type")]
                    public string Type { init; get; }
                    [JsonPropertyName("attributes")]
                    public Attributes Attributes { init; get; }
                }
                public class Attributes {
                    [JsonPropertyName("url")]
                    public string Url { init; get; }
                    [JsonPropertyName("expires_at")]
                    public string ExpiresAt { init; get; }
                }
            }
            public class EInvoiceInboxes {
                [JsonPropertyName("errors")]
                public List<EInvoiceInboxesError> Errors { init; get; }
                public class EInvoiceInboxesError {
                    [JsonPropertyName("title")]
                    public string Title { init; get; }
                    [JsonPropertyName("detail")]
                    public string Detail { init; get; }
                }
                [JsonPropertyName("data")]
                public List<EInvoiceInboxesData> Data { init; get; }
                public class EInvoiceInboxesData {
                    [JsonPropertyName("id")]
                    public string Id { init; get; }
                    [JsonPropertyName("type")]
                    public string Type { init; get; }
                    [JsonPropertyName("attributes")]
                    public Attributes Attributes { init; get; }
                }
                public class Attributes {
                    [JsonPropertyName("vkn")]
                    public string VKN { init; get; }
                    [JsonPropertyName("e_invoice_address")]
                    public string EInvoiceAddress { init; get; }
                    [JsonPropertyName("name")]
                    public string Name { init; get; }
                    [JsonPropertyName("inbox_type")]
                    public string InboxType { init; get; }
                    [JsonPropertyName("address_registered_at")]
                    public string AddressRegisteredAt { init; get; }
                    [JsonPropertyName("registered_at")]
                    public string RegisteredAt { init; get; }
                    [JsonPropertyName("created_at")]
                    public string CreatedAt { init; get; }
                    [JsonPropertyName("updated_at")]
                    public string UpdatedAt { init; get; }
                }
            }
        }
        public void SetCompanyId(string companyid) {
            CompanyId = companyid;
        }
        public void SetClientId(string clientid) {
            ClientId = clientid;
        }
        public void SetClientSecret(string clientsecret) {
            ClientSecret = clientsecret;
        }
        public void SetUsername(string username) {
            Username = username;
        }
        public void SetPassword(string password) {
            Password = password;
        }
        public void Authentication() {
            try {
                var http = new HttpClient();
                var data = new Request.Authentication { ClientId = ClientId, ClientSecret = ClientSecret, Username = Username, Password = Password, GrantType = "password", RedirectURI = "urn:ietf:wg:oauth:2.0:oob" };
                var request = new HttpRequestMessage(HttpMethod.Post, "https://api.parasut.com/oauth/token") { Content = new StringContent(QueryString(data), Encoding.UTF8, "application/x-www-form-urlencoded") };
                var response = http.Send(request);
                var result = JsonSerializer.Deserialize<Response.Authentication>(response.Content.ReadAsStream());
                Token = result.AccessToken;
            } catch (Exception err) {
                if (err.InnerException != null) {
                    Console.WriteLine(err.InnerException.Message);
                } else {
                    Console.WriteLine(err.Message);
                }
            }
        }
        public Response.SalesInvoice.SalesInvoiceData CreateSalesInvoice(Request.SalesInvoice data) {
            try {
                var http = new HttpClient() { DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", Token) } };
                var request = new HttpRequestMessage(HttpMethod.Post, Endpoint + CompanyId + "/sales_invoices") { Content = new StringContent(JsonString(data), Encoding.UTF8, MediaTypeNames.Application.Json) };
                var response = http.Send(request);
                var result = JsonSerializer.Deserialize<Response.SalesInvoice>(response.Content.ReadAsStream());
                return result.Data;
            } catch (Exception err) {
                if (err.InnerException != null) {
                    Console.WriteLine(err.InnerException.Message);
                } else {
                    Console.WriteLine(err.Message);
                }
            }
            return null;
        }
        public Response.SalesInvoice.SalesInvoiceData ShowSalesInvoice(string id) {
            try {
                var http = new HttpClient() { DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", Token) } };
                var request = new HttpRequestMessage(HttpMethod.Get, Endpoint + CompanyId + "/sales_invoices/" + id + "?include=category,contact,details,payments,tags,sharings,recurrence_plan,active_e_document");
                var response = http.Send(request);
                var result = JsonSerializer.Deserialize<Response.SalesInvoice>(response.Content.ReadAsStream());
                return result.Data;
            } catch (Exception err) {
                if (err.InnerException != null) {
                    Console.WriteLine(err.InnerException.Message);
                } else {
                    Console.WriteLine(err.Message);
                }
            }
            return null;
        }
        public Response.SalesInvoice.SalesInvoiceData CancelSalesInvoice(string id) {
            try {
                var http = new HttpClient() { DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", Token) } };
                var request = new HttpRequestMessage(HttpMethod.Delete, Endpoint + CompanyId + "/sales_invoices/" + id + "/cancel");
                var response = http.Send(request);
                var result = JsonSerializer.Deserialize<Response.SalesInvoice>(response.Content.ReadAsStream());
                return result.Data;
            } catch (Exception err) {
                if (err.InnerException != null) {
                    Console.WriteLine(err.InnerException.Message);
                } else {
                    Console.WriteLine(err.Message);
                }
            }
            return null;
        }
        public Response.SalesInvoice.SalesInvoiceData DeleteSalesInvoice(string id) {
            try {
                var http = new HttpClient() { DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", Token) } };
                var request = new HttpRequestMessage(HttpMethod.Delete, Endpoint + CompanyId + "/sales_invoices/" + id);
                var response = http.Send(request);
                var result = JsonSerializer.Deserialize<Response.SalesInvoice>(response.Content.ReadAsStream());
                return result.Data;
            } catch (Exception err) {
                if (err.InnerException != null) {
                    Console.WriteLine(err.InnerException.Message);
                } else {
                    Console.WriteLine(err.Message);
                }
            }
            return null;
        }
        public Response.SalesInvoice.SalesInvoiceData RecoverSalesInvoice(string id) {
            try {
                var http = new HttpClient() { DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", Token) } };
                var request = new HttpRequestMessage(HttpMethod.Patch, Endpoint + CompanyId + "/sales_invoices/" + id + "/recover");
                var response = http.Send(request);
                var result = JsonSerializer.Deserialize<Response.SalesInvoice>(response.Content.ReadAsStream());
                return result.Data;
            } catch (Exception err) {
                if (err.InnerException != null) {
                    Console.WriteLine(err.InnerException.Message);
                } else {
                    Console.WriteLine(err.Message);
                }
            }
            return null;
        }
        public Response.SalesInvoice.SalesInvoiceData ArchiveSalesInvoice(string id) {
            try {
                var http = new HttpClient() { DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", Token) } };
                var request = new HttpRequestMessage(HttpMethod.Patch, Endpoint + CompanyId + "/sales_invoices/" + id + "/archive");
                var response = http.Send(request);
                var result = JsonSerializer.Deserialize<Response.SalesInvoice>(response.Content.ReadAsStream());
                return result.Data;
            } catch (Exception err) {
                if (err.InnerException != null) {
                    Console.WriteLine(err.InnerException.Message);
                } else {
                    Console.WriteLine(err.Message);
                }
            }
            return null;
        }
        public Response.SalesInvoice.SalesInvoiceData UnarchiveSalesInvoice(string id) {
            try {
                var http = new HttpClient() { DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", Token) } };
                var request = new HttpRequestMessage(HttpMethod.Patch, Endpoint + CompanyId + "/sales_invoices/" + id + "/unarchive");
                var response = http.Send(request);
                var result = JsonSerializer.Deserialize<Response.SalesInvoice>(response.Content.ReadAsStream());
                return result.Data;
            } catch (Exception err) {
                if (err.InnerException != null) {
                    Console.WriteLine(err.InnerException.Message);
                } else {
                    Console.WriteLine(err.Message);
                }
            }
            return null;
        }
        public Response.SalesInvoice.SalesInvoiceData ConvertSalesInvoice(string id) {
            try {
                var http = new HttpClient() { DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", Token) } };
                var request = new HttpRequestMessage(HttpMethod.Patch, Endpoint + CompanyId + "/sales_invoices/" + id + "/convert_to_invoice");
                var response = http.Send(request);
                var result = JsonSerializer.Deserialize<Response.SalesInvoice>(response.Content.ReadAsStream());
                return result.Data;
            } catch (Exception err) {
                if (err.InnerException != null) {
                    Console.WriteLine(err.InnerException.Message);
                } else {
                    Console.WriteLine(err.Message);
                }
            }
            return null;
        }
        public Response.EArchive.EArchiveData CreateEArchive(Request.EArchive data) {
            try {
                var http = new HttpClient() { DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", Token) } };
                var request = new HttpRequestMessage(HttpMethod.Post, Endpoint + CompanyId + "/e_archives") { Content = new StringContent(JsonString(data), Encoding.UTF8, MediaTypeNames.Application.Json) };
                var response = http.Send(request);
                var result = JsonSerializer.Deserialize<Response.EArchive>(response.Content.ReadAsStream());
                return result.Data;
            } catch (Exception err) {
                if (err.InnerException != null) {
                    Console.WriteLine(err.InnerException.Message);
                } else {
                    Console.WriteLine(err.Message);
                }
            }
            return null;
        }
        public Response.EInvoice.EInvoiceData CreateEInvoice(Request.EInvoice data) {
            try {
                var http = new HttpClient() { DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", Token) } };
                var request = new HttpRequestMessage(HttpMethod.Post, Endpoint + CompanyId + "/e_invoices") { Content = new StringContent(JsonString(data), Encoding.UTF8, MediaTypeNames.Application.Json) };
                var response = http.Send(request);
                var result = JsonSerializer.Deserialize<Response.EInvoice>(response.Content.ReadAsStream());
                return result.Data;
            } catch (Exception err) {
                if (err.InnerException != null) {
                    Console.WriteLine(err.InnerException.Message);
                } else {
                    Console.WriteLine(err.Message);
                }
            }
            return null;
        }
        public Response.EArchive.EArchiveData ShowEArchive(string id) {
            try {
                var http = new HttpClient() { DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", Token) } };
                var request = new HttpRequestMessage(HttpMethod.Get, Endpoint + CompanyId + "/e_archives/" + id);
                var response = http.Send(request);
                var result = JsonSerializer.Deserialize<Response.EArchive>(response.Content.ReadAsStream());
                return result.Data;
            } catch (Exception err) {
                if (err.InnerException != null) {
                    Console.WriteLine(err.InnerException.Message);
                } else {
                    Console.WriteLine(err.Message);
                }
            }
            return null;
        }
        public Response.EInvoice.EInvoiceData ShowEInvoice(string id) {
            try {
                var http = new HttpClient() { DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", Token) } };
                var request = new HttpRequestMessage(HttpMethod.Get, Endpoint + CompanyId + "/e_invoices/" + id);
                var response = http.Send(request);
                var result = JsonSerializer.Deserialize<Response.EInvoice>(response.Content.ReadAsStream());
                return result.Data;
            } catch (Exception err) {
                if (err.InnerException != null) {
                    Console.WriteLine(err.InnerException.Message);
                } else {
                    Console.WriteLine(err.Message);
                }
            }
            return null;
        }
        public Response.EArchivePDF.EArchivePDFData ShowEArchivePDF(string id) {
            try {
                var http = new HttpClient() { DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", Token) } };
                var request = new HttpRequestMessage(HttpMethod.Get, Endpoint + CompanyId + "/e_archives/" + id + "/pdf");
                var response = http.Send(request);
                var result = JsonSerializer.Deserialize<Response.EArchivePDF>(response.Content.ReadAsStream());
                return result.Data;
            } catch (Exception err) {
                if (err.InnerException != null) {
                    Console.WriteLine(err.InnerException.Message);
                } else {
                    Console.WriteLine(err.Message);
                }
            }
            return null;
        }
        public Response.EInvoicePDF.EInvoicePDFData ShowEInvoicePDF(string id) {
            try {
                var http = new HttpClient() { DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", Token) } };
                var request = new HttpRequestMessage(HttpMethod.Get, Endpoint + CompanyId + "/e_invoices/" + id + "/pdf");
                var response = http.Send(request);
                var result = JsonSerializer.Deserialize<Response.EInvoicePDF>(response.Content.ReadAsStream());
                return result.Data;
            } catch (Exception err) {
                if (err.InnerException != null) {
                    Console.WriteLine(err.InnerException.Message);
                } else {
                    Console.WriteLine(err.Message);
                }
            }
            return null;
        }
        public List<Response.EInvoiceInboxes.EInvoiceInboxesData> ListEInvoiceInboxes(string vkn) {
            try {
                var http = new HttpClient() { DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", Token) } };
                var request = new HttpRequestMessage(HttpMethod.Get, Endpoint + CompanyId + "/e_invoice_inboxes?filter[vkn]=" + vkn);
                var response = http.Send(request);
                var result = JsonSerializer.Deserialize<Response.EInvoiceInboxes>(response.Content.ReadAsStream());
                if (result.Errors != null && result.Errors.Any()) {
                    foreach (var error in result.Errors) {
                        Console.WriteLine(error.Detail);
                    }
                } else {
                    return result.Data.ToList();
                }
            } catch (Exception err) {
                if (err.InnerException != null) {
                    Console.WriteLine(err.InnerException.Message);
                } else {
                    Console.WriteLine(err.Message);
                }
            }
            return null;
        }
        private static string QueryString<T>(T data) where T : class {
            return string.Join("&", typeof(T).GetProperties().Where(p => p.GetValue(data, null) != null).Select(p => $"{p.GetCustomAttribute<JsonPropertyNameAttribute>().Name}={p.GetValue(data)}"));
        }
        private static string JsonString<T>(T data) where T : class {
            return JsonSerializer.Serialize(data, new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, WriteIndented = true });
        }
    }
}