using System.Collections.Specialized;
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
        bool Authentication();
        Parasut.Response.SalesInvoice CreateSalesInvoice(Parasut.Request.SalesInvoice invoice);
        Parasut.Response.SalesInvoice ShowSalesInvoice(string id);
        Parasut.Response.SalesInvoice DeleteSalesInvoice(string id);
        Parasut.Response.SalesInvoice RecoverSalesInvoice(string id);
        Parasut.Response.SalesInvoice ArchiveSalesInvoice(string id);
        Parasut.Response.SalesInvoice UnarchiveSalesInvoice(string id);
        Parasut.Response.SalesInvoice CancelSalesInvoice(string id);
        Parasut.Response.SalesInvoice ConvertSalesInvoice(string id);
        Parasut.Response.Contacts SearchContact(Parasut.Request.Contact search);
        Parasut.Response.Contact CreateContact(Parasut.Request.Contact contact);
        Parasut.Response.Contact ShowContact(string id);
        Parasut.Response.Contact DeleteContact(string id);
        Parasut.Response.EArchive CreateEArchive(Parasut.Request.EArchive earchive);
        Parasut.Response.EInvoice CreateEInvoice(Parasut.Request.EInvoice einvoice);
        Parasut.Response.EArchive ShowEArchive(string id);
        Parasut.Response.EInvoice ShowEInvoice(string id);
        Parasut.Response.EArchivePDF ShowEArchivePDF(string id);
        Parasut.Response.EInvoicePDF ShowEInvoicePDF(string id);
        Parasut.Response.EInvoiceInboxes ListEInvoiceInboxes(string vkn);
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
            public class Authentication : Request {
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
            public class Contact : Request {
                [JsonPropertyName("data")]
                public ContactData Data { init; get; }
            }
            public class SalesInvoice : Request {
                [JsonPropertyName("data")]
                public SalesInvoiceData Data { init; get; }
            }
            public class ContactData : Contact {
                public ContactData() {
                    Type = "contacts";
                }
                [JsonPropertyName("id")]
                public string Id { init; get; }
                [JsonPropertyName("type")]
                public string Type { init; get; }
                [JsonPropertyName("attributes")]
                public ContactAttributes Attributes { init; get; }
                [JsonPropertyName("relationships")]
                public ContactRelationships Relationships { init; get; }
                public class ContactAttributes {
                    [JsonPropertyName("email")]
                    public string Email { init; get; }
                    [JsonPropertyName("name")]
                    public string Name { init; get; }
                    [JsonPropertyName("short_name")]
                    public string ShortName { init; get; }
                    [JsonPropertyName("contact_type")]
                    public string ContactType { init; get; }
                    [JsonPropertyName("account_type")]
                    public string AccountType { init; get; }
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
                    [JsonPropertyName("address")]
                    public string Address { init; get; }
                    [JsonPropertyName("phone")]
                    public string Phone { init; get; }
                    [JsonPropertyName("fax")]
                    public string Fax { init; get; }
                    [JsonPropertyName("iban")]
                    public string IBAN { init; get; }
                    [JsonPropertyName("is_abroad")]
                    public bool? IsAbroad { init; get; }
                    [JsonPropertyName("archived")]
                    public bool? Archived { init; get; }
                    [JsonPropertyName("untrackable")]
                    public bool? Untrackable { init; get; }
                }
                public class ContactRelationships {
                    [JsonPropertyName("category")]
                    public ContactCategory ContactCategory { get; set; }
                    [JsonPropertyName("contact_people")]
                    public ContactPeople ContactPeople { get; set; }
                }
                public class ContactCategory {
                    [JsonPropertyName("data")]
                    public ContactCategoryData Data { init; get; }
                }
                public class ContactPeople {
                    [JsonPropertyName("data")]
                    public ContactPeopleData[] Data { init; get; }
                }
                public class ContactCategoryData {
                    public ContactCategoryData() {
                        Type = "item_categories";
                    }
                    [JsonPropertyName("id")]
                    public string Id { init; get; }
                    [JsonPropertyName("type")]
                    public string Type { init; get; }
                }
                public class ContactPeopleData {
                    public ContactPeopleData() {
                        Type = "contact_people";
                    }
                    [JsonPropertyName("id")]
                    public string Id { init; get; }
                    [JsonPropertyName("type")]
                    public string Type { init; get; }
                    [JsonPropertyName("attributes")]
                    public ContactPeopleAttributes Attributes { init; get; }
                }
                public class ContactPeopleAttributes {
                    [JsonPropertyName("name")]
                    public string Name { init; get; }
                    [JsonPropertyName("email")]
                    public string Email { init; get; }
                    [JsonPropertyName("phone")]
                    public string Phone { init; get; }
                    [JsonPropertyName("notes")]
                    public string Notes { init; get; }
                }
            }
            public class SalesInvoiceData : SalesInvoice {
                public SalesInvoiceData() {
                    Type = "sales_invoices";
                }
                [JsonPropertyName("id")]
                public string Id { init; get; }
                [JsonPropertyName("type")]
                public string Type { init; get; }
                [JsonPropertyName("attributes")]
                public SalesInvoiceAttributes Attributes { init; get; }
                [JsonPropertyName("relationships")]
                public SalesInvoiceRelationships Relationships { init; get; }
                public class SalesInvoiceAttributes {
                    [JsonPropertyName("invoice_id")]
                    public int? InvoiceId { init; get; }
                    [JsonPropertyName("invoice_series")]
                    public string InvoiceSeries { init; get; }
                    [JsonPropertyName("item_type")]
                    public string ItemType { init; get; }
                    [JsonPropertyName("description")]
                    public string Description { init; get; }
                    [JsonPropertyName("issue_date")]
                    public string IssueDate { init; get; }
                    [JsonPropertyName("due_date")]
                    public string DueDate { init; get; }
                    [JsonPropertyName("order_date")]
                    public string OrderDate { init; get; }
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
                public class SalesInvoiceRelationships {
                    [JsonPropertyName("category")]
                    public SalesInvoiceCategory Category { get; set; }
                    [JsonPropertyName("contact")]
                    public SalesInvoiceContact Contact { get; set; }
                    [JsonPropertyName("details")]
                    public SalesInvoiceDetails Details { get; set; }
                    [JsonPropertyName("tags")]
                    public SalesInvoiceTags Tags { get; set; }
                    [JsonPropertyName("sales_offer")]
                    public SalesInvoiceSalesOffer SalesOffer { get; set; }
                }
                public class SalesInvoiceCategory {
                    [JsonPropertyName("data")]
                    public SalesInvoiceCategoryData Data { init; get; }
                }
                public class SalesInvoiceContact {
                    [JsonPropertyName("data")]
                    public SalesInvoiceContactData Data { init; get; }
                }
                public class SalesInvoiceDetails {
                    [JsonPropertyName("data")]
                    public SalesInvoiceDetailsData[] Data { init; get; }
                }
                public class SalesInvoiceTags {
                    [JsonPropertyName("data")]
                    public SalesInvoiceTagsData[] Data { init; get; }
                }
                public class SalesInvoiceSalesOffer {
                    [JsonPropertyName("data")]
                    public SalesInvoiceSalesOfferData Data { init; get; }
                }
                public class SalesInvoiceCategoryData {
                    public SalesInvoiceCategoryData() {
                        Type = "item_categories";
                    }
                    [JsonPropertyName("id")]
                    public string Id { init; get; }
                    [JsonPropertyName("type")]
                    public string Type { init; get; }
                }
                public class SalesInvoiceContactData {
                    public SalesInvoiceContactData() {
                        Type = "contacts";
                    }
                    [JsonPropertyName("id")]
                    public string Id { init; get; }
                    [JsonPropertyName("type")]
                    public string Type { init; get; }
                }
                public class SalesInvoiceDetailsData {
                    public SalesInvoiceDetailsData() {
                        Type = "sales_invoice_details";
                    }
                    [JsonPropertyName("id")]
                    public string Id { init; get; }
                    [JsonPropertyName("type")]
                    public string Type { init; get; }
                    [JsonPropertyName("attributes")]
                    public SalesInvoiceDetailsAttributes Attributes { init; get; }
                    [JsonPropertyName("relationships")]
                    public SalesInvoiceDetailsRelationships Relationships { init; get; }
                    public class SalesInvoiceDetailsAttributes {
                        [JsonPropertyName("quantity")]
                        public string Quantity { init; get; }
                        [JsonPropertyName("unit_price")]
                        public string UnitPrice { init; get; }
                        [JsonPropertyName("vat_rate")]
                        public string VatRate { init; get; }
                        [JsonPropertyName("discount_type")]
                        public string DiscountType { init; get; }
                        [JsonPropertyName("discount_value")]
                        public string DiscountValue { init; get; }
                        [JsonPropertyName("excise_duty_type")]
                        public string ExciseDutyType { init; get; }
                        [JsonPropertyName("excise_duty_value")]
                        public string ExciseDutyValue { init; get; }
                        [JsonPropertyName("communications_tax_rate")]
                        public string CommunicationsTaxRate { init; get; }
                        [JsonPropertyName("description")]
                        public string Description { init; get; }
                        [JsonPropertyName("delivery_method")]
                        public string DeliveryMethod { init; get; }
                        [JsonPropertyName("shipping_method")]
                        public string ShippingMethod { init; get; }
                    }
                    public class SalesInvoiceDetailsRelationships {
                        [JsonPropertyName("product")]
                        public SalesInvoiceDetailsProduct Product { get; set; }
                        [JsonPropertyName("warehouse")]
                        public SalesInvoiceDetailsWarehouse Warehouse { get; set; }
                    }
                    public class SalesInvoiceDetailsProduct {
                        [JsonPropertyName("data")]
                        public SalesInvoiceDetailsProductData Data { init; get; }
                    }
                    public class SalesInvoiceDetailsProductData {
                        public SalesInvoiceDetailsProductData() {
                            Type = "products";
                        }
                        [JsonPropertyName("id")]
                        public string Id { init; get; }
                        [JsonPropertyName("type")]
                        public string Type { init; get; }
                    }
                    public class SalesInvoiceDetailsWarehouse {
                        [JsonPropertyName("data")]
                        public SalesInvoiceDetailsWarehouseData Data { init; get; }
                    }
                    public class SalesInvoiceDetailsWarehouseData {
                        public SalesInvoiceDetailsWarehouseData() {
                            Type = "warehouses";
                        }
                        [JsonPropertyName("id")]
                        public string Id { init; get; }
                        [JsonPropertyName("type")]
                        public string Type { init; get; }
                    }
                }
                public class SalesInvoiceTagsData {
                    public SalesInvoiceTagsData() {
                        Type = "tags";
                    }
                    [JsonPropertyName("id")]
                    public string Id { init; get; }
                    [JsonPropertyName("type")]
                    public string Type { init; get; }
                }
                public class SalesInvoiceSalesOfferData {
                    public SalesInvoiceSalesOfferData() {
                        Type = "sales_offers";
                    }
                    [JsonPropertyName("id")]
                    public string Id { init; get; }
                    [JsonPropertyName("type")]
                    public string Type { init; get; }
                }
            }
            public class EArchive : Request {
                [JsonPropertyName("data")]
                public EArchiveData Data { init; get; }
            }
            public class EArchiveData : EArchive {
                public EArchiveData() {
                    Type = "e_archives";
                }
                [JsonPropertyName("id")]
                public string Id { init; get; }
                [JsonPropertyName("type")]
                public string Type { init; get; }
                [JsonPropertyName("attributes")]
                public EArchiveAttributes Attributes { init; get; }
                [JsonPropertyName("relationships")]
                public EArchiveRelationships Relationships { init; get; }
                public class EArchiveAttributes {
                    [JsonPropertyName("note")]
                    public string Note { init; get; }
                    [JsonPropertyName("internet_sale")]
                    public InternetSaleData InternetSale { init; get; }
                    [JsonPropertyName("shipment")]
                    public ShipmentData Shipment { init; get; }
                    [JsonPropertyName("excise_duty_codes")]
                    public EArchiveExciseDutyCode[] ExciseDutyCodes { init; get; }
                    [JsonPropertyName("vat_withholding_code")]
                    public string VatWithholdingCode { init; get; }
                    [JsonPropertyName("vat_exemption_reason_code")]
                    public string VatExemptionReasonCode { init; get; }
                    [JsonPropertyName("vat_exemption_reason")]
                    public string VatExemptionReason { init; get; }
                }
                public class EArchiveRelationships {
                    [JsonPropertyName("sales_invoice")]
                    public EArchiveSalesInvoice SalesInvoice { get; set; }
                }
                public class EArchiveExciseDutyCode {
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
                public class EArchiveSalesInvoice {
                    [JsonPropertyName("data")]
                    public EArchiveSalesInvoiceData Data { init; get; }
                }
                public class EArchiveSalesInvoiceData {
                    public EArchiveSalesInvoiceData() {
                        Type = "sales_invoices";
                    }
                    [JsonPropertyName("id")]
                    public string Id { init; get; }
                    [JsonPropertyName("type")]
                    public string Type { init; get; }
                }
            }
            public class EInvoice : Request {
                [JsonPropertyName("data")]
                public EInvoiceData Data { init; get; }
            }
            public class EInvoiceData : EInvoice {
                public EInvoiceData() {
                    Type = "e_invoices";
                }
                [JsonPropertyName("id")]
                public string Id { init; get; }
                [JsonPropertyName("type")]
                public string Type { init; get; }
                [JsonPropertyName("attributes")]
                public EInvoiceAttributes Attributes { init; get; }
                [JsonPropertyName("relationships")]
                public EInvoiceRelationships Relationships { init; get; }
                public class EInvoiceAttributes {
                    [JsonPropertyName("to")]
                    public string To { init; get; }
                    [JsonPropertyName("scenario")]
                    public string Scenario { init; get; }
                    [JsonPropertyName("note")]
                    public string Note { init; get; }
                    [JsonPropertyName("excise_duty_codes")]
                    public EInvoiceExciseDutyCode[] ExciseDutyCodes { init; get; }
                    [JsonPropertyName("vat_withholding_code")]
                    public string VatWithholdingCode { init; get; }
                    [JsonPropertyName("vat_exemption_reason_code")]
                    public string VatExemptionReasonCode { init; get; }
                    [JsonPropertyName("vat_exemption_reason")]
                    public string VatExemptionReason { init; get; }
                    [JsonPropertyName("custom_requirement_params")]
                    public CustomRequirementParam CustomRequirementParams { init; get; }
                }
                public class EInvoiceExciseDutyCode {
                    [JsonPropertyName("product")]
                    public int? Product { init; get; }
                    [JsonPropertyName("sales_excise_duty_code")]
                    public string SalesExciseDutyCode { init; get; }
                }
                public class CustomRequirementParam {
                    [JsonPropertyName("integration")]
                    public CustomIntegration Integration { init; get; }
                }
                public class CustomIntegration {
                    [JsonPropertyName("data")]
                    public IntegrationData Data { init; get; }
                }
                public class IntegrationData {
                    [JsonPropertyName("additional_invoice_type")]
                    public string AdditionalInvoiceType { init; get; }
                    [JsonPropertyName("tax_payer_code")]
                    public string TaxPayerCode { init; get; }
                    [JsonPropertyName("tax_payer_name")]
                    public string TaxPayerName { init; get; }
                    [JsonPropertyName("file_number")]
                    public string FileNumber { init; get; }
                    [JsonPropertyName("term_start_date")]
                    public string TermStartDate { init; get; }
                    [JsonPropertyName("term_end_date")]
                    public string TermEndDate { init; get; }
                }
                public class EInvoiceRelationships {
                    [JsonPropertyName("invoice")]
                    public EInvoiceInvoice Invoice { get; set; }
                }
                public class EInvoiceInvoice {
                    [JsonPropertyName("data")]
                    public EInvoiceInvoiceData Data { init; get; }
                }
                public class EInvoiceInvoiceData {
                    public EInvoiceInvoiceData() {
                        Type = "sales_invoices";
                    }
                    [JsonPropertyName("id")]
                    public string Id { init; get; }
                    [JsonPropertyName("type")]
                    public string Type { init; get; }
                }
            }
        }
        public class Response {
            public class Authentication : Response {
                [JsonPropertyName("token_type")]
                public string TokenType { init; get; }
                [JsonPropertyName("access_token")]
                public string AccessToken { init; get; }
                [JsonPropertyName("refresh_token")]
                public string RefreshToken { init; get; }
                [JsonPropertyName("expires_in")]
                public int? ExpiresIn { init; get; }
                [JsonPropertyName("created_at")]
                public long? CreatedAt { init; get; }
                [JsonPropertyName("scope")]
                public string Scope { init; get; }
                [JsonPropertyName("errors")]
                public List<ResponseError> Errors { init; get; }
            }
            public class Contact : Response {
                [JsonPropertyName("errors")]
                public List<ResponseError> Errors { init; get; }
                [JsonPropertyName("data")]
                public ContactData Data { init; get; }
            }
            public class Contacts : Response {
                [JsonPropertyName("errors")]
                public List<ResponseError> Errors { init; get; }
                [JsonPropertyName("data")]
                public ContactData[] Data { init; get; }
            }
            public class ContactData : Contact {
                [JsonPropertyName("id")]
                public string Id { init; get; }
                [JsonPropertyName("type")]
                public string Type { init; get; }
                [JsonPropertyName("attributes")]
                public ContactAttributes Attributes { init; get; }
                [JsonPropertyName("relationships")]
                public ContactRelationships Relationships { init; get; }
                public class ContactAttributes {
                    [JsonPropertyName("balance")]
                    public string Balance { init; get; }
                    [JsonPropertyName("trl_balance")]
                    public string TRLBalance { init; get; }
                    [JsonPropertyName("usd_balance")]
                    public string USDBalance { init; get; }
                    [JsonPropertyName("eur_balance")]
                    public string EURBalance { init; get; }
                    [JsonPropertyName("gbp_balance")]
                    public string GBPBalance { init; get; }
                    [JsonPropertyName("email")]
                    public string Email { init; get; }
                    [JsonPropertyName("name")]
                    public string Name { init; get; }
                    [JsonPropertyName("short_name")]
                    public string ShortName { init; get; }
                    [JsonPropertyName("contact_type")]
                    public string ContactType { init; get; }
                    [JsonPropertyName("account_type")]
                    public string AccountType { init; get; }
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
                    [JsonPropertyName("address")]
                    public string Address { init; get; }
                    [JsonPropertyName("phone")]
                    public string Phone { init; get; }
                    [JsonPropertyName("fax")]
                    public string Fax { init; get; }
                    [JsonPropertyName("iban")]
                    public string IBAN { init; get; }
                    [JsonPropertyName("is_abroad")]
                    public bool? IsAbroad { init; get; }
                    [JsonPropertyName("archived")]
                    public bool? Archived { init; get; }
                    [JsonPropertyName("untrackable")]
                    public bool? Untrackable { init; get; }
                    [JsonPropertyName("created_at")]
                    public string CreatedAt { init; get; }
                    [JsonPropertyName("updated_at")]
                    public string UpdatedAt { init; get; }
                }
                public class ContactRelationships {
                    [JsonPropertyName("category")]
                    public ContactCategory ContactCategory { get; set; }
                    [JsonPropertyName("contact_portal")]
                    public ContactPortal ContactPortal { get; set; }
                    [JsonPropertyName("contact_people")]
                    public ContactPeople ContactPeople { get; set; }
                }
                public class ContactCategory {
                    [JsonPropertyName("data")]
                    public ContactCategoryData Data { init; get; }
                }
                public class ContactPortal {
                    [JsonPropertyName("data")]
                    public ContactPortalData Data { init; get; }
                }
                public class ContactPeople {
                    [JsonPropertyName("data")]
                    public ContactPeopleData[] Data { init; get; }
                }
                public class ContactCategoryData {
                    [JsonPropertyName("id")]
                    public string Id { init; get; }
                    [JsonPropertyName("type")]
                    public string Type { init; get; }
                }
                public class ContactPortalData {
                    [JsonPropertyName("id")]
                    public string Id { init; get; }
                    [JsonPropertyName("type")]
                    public string Type { init; get; }
                }
                public class ContactPeopleData {
                    [JsonPropertyName("id")]
                    public string Id { init; get; }
                    [JsonPropertyName("type")]
                    public string Type { init; get; }
                }
            }
            public class SalesInvoice : Response {
                [JsonPropertyName("errors")]
                public List<ResponseError> Errors { init; get; }
                [JsonPropertyName("data")]
                public SalesInvoiceData Data { init; get; }
            }
            public class SalesInvoiceData : SalesInvoice {
                [JsonPropertyName("id")]
                public string Id { init; get; }
                [JsonPropertyName("type")]
                public string Type { init; get; }
                [JsonPropertyName("attributes")]
                public SalesInvoiceAttributes Attributes { init; get; }
                [JsonPropertyName("relationships")]
                public SalesInvoiceRelationships Relationships { init; get; }
                public class SalesInvoiceAttributes {
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
                    public string IssueDate { init; get; }
                    [JsonPropertyName("due_date")]
                    public string DueDate { init; get; }
                    [JsonPropertyName("order_date")]
                    public string OrderDate { init; get; }
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
                public class SalesInvoiceRelationships {
                    [JsonPropertyName("category")]
                    public SalesInvoiceCategory Category { get; set; }
                    [JsonPropertyName("contact")]
                    public SalesInvoiceContact Contact { get; set; }
                    [JsonPropertyName("details")]
                    public SalesInvoiceDetails Details { get; set; }
                    [JsonPropertyName("payments")]
                    public SalesInvoicePayments Payments { get; set; }
                    [JsonPropertyName("tags")]
                    public SalesInvoiceTags Tags { get; set; }
                    [JsonPropertyName("sales_offer")]
                    public SalesInvoiceSalesOffer SalesOffer { get; set; }
                    [JsonPropertyName("sharings")]
                    public SalesInvoiceSharings Sharings { get; set; }
                    [JsonPropertyName("recurrence_plan")]
                    public SalesInvoiceRecurrencePlan RecurrencePlan { get; set; }
                    [JsonPropertyName("active_e_document")]
                    public SalesInvoiceActiveEDocument ActiveEDocument { get; set; }
                }
                public class SalesInvoiceCategory {
                    [JsonPropertyName("data")]
                    public SalesInvoiceCategoryData Data { init; get; }
                }
                public class SalesInvoiceCategoryData {
                    [JsonPropertyName("id")]
                    public string Id { init; get; }
                    [JsonPropertyName("type")]
                    public string Type { init; get; }
                }
                public class SalesInvoiceContact {
                    [JsonPropertyName("data")]
                    public SalesInvoiceContactData Data { init; get; }
                }
                public class SalesInvoiceContactData {
                    [JsonPropertyName("id")]
                    public string Id { init; get; }
                    [JsonPropertyName("type")]
                    public string Type { init; get; }
                }
                public class SalesInvoiceDetails {
                    [JsonPropertyName("data")]
                    public SalesInvoiceDetailsData[] Data { init; get; }
                }
                public class SalesInvoiceDetailsData {
                    [JsonPropertyName("id")]
                    public string Id { init; get; }
                    [JsonPropertyName("type")]
                    public string Type { init; get; }
                }
                public class SalesInvoicePayments {
                    [JsonPropertyName("data")]
                    public SalesInvoicePaymentsData[] Data { init; get; }
                }
                public class SalesInvoicePaymentsData {
                    [JsonPropertyName("id")]
                    public string Id { init; get; }
                    [JsonPropertyName("type")]
                    public string Type { init; get; }
                }
                public class SalesInvoiceTags {
                    [JsonPropertyName("data")]
                    public SalesInvoiceTagsData[] Data { init; get; }
                }
                public class SalesInvoiceTagsData {
                    [JsonPropertyName("id")]
                    public string Id { init; get; }
                    [JsonPropertyName("type")]
                    public string Type { init; get; }
                }
                public class SalesInvoiceSalesOffer {
                    [JsonPropertyName("data")]
                    public SalesInvoiceSalesOfferData Data { init; get; }
                }
                public class SalesInvoiceSalesOfferData {
                    [JsonPropertyName("id")]
                    public string Id { init; get; }
                    [JsonPropertyName("type")]
                    public string Type { init; get; }
                }
                public class SalesInvoiceSharings {
                    [JsonPropertyName("data")]
                    public SalesInvoiceSharingsData[] Data { init; get; }
                }
                public class SalesInvoiceSharingsData {
                    [JsonPropertyName("id")]
                    public string Id { init; get; }
                    [JsonPropertyName("type")]
                    public string Type { init; get; }
                }
                public class SalesInvoiceRecurrencePlan {
                    [JsonPropertyName("data")]
                    public SalesInvoiceRecurrencePlanData Data { init; get; }
                }
                public class SalesInvoiceRecurrencePlanData {
                    [JsonPropertyName("id")]
                    public string Id { init; get; }
                    [JsonPropertyName("type")]
                    public string Type { init; get; }
                }
                public class SalesInvoiceActiveEDocument {
                    [JsonPropertyName("data")]
                    public SalesInvoiceActiveEDocumentData Data { init; get; }
                }
                public class SalesInvoiceActiveEDocumentData {
                    [JsonPropertyName("id")]
                    public string Id { init; get; }
                    [JsonPropertyName("type")]
                    public string Type { init; get; }
                }
            }
            public class EArchive : Response {
                [JsonPropertyName("errors")]
                public List<ResponseError> Errors { init; get; }
                [JsonPropertyName("data")]
                public EArchiveData Data { init; get; }
            }
            public class EArchiveData : EArchive {
                [JsonPropertyName("id")]
                public string Id { init; get; }
                [JsonPropertyName("type")]
                public string Type { init; get; }
                [JsonPropertyName("attributes")]
                public EArchiveAttributes Attributes { init; get; }
                [JsonPropertyName("relationships")]
                public EArchiveRelationships Relationships { init; get; }
                [JsonPropertyName("links")]
                public EArchiveLinks Links { init; get; }
                public class EArchiveAttributes {
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
                    [JsonPropertyName("cancellable_until")]
                    public string CancellableUntil { init; get; }
                    [JsonPropertyName("is_signed")]
                    public bool? IsSigned { init; get; }
                    [JsonPropertyName("printed_at")]
                    public long? PrintedAt { init; get; }
                    [JsonPropertyName("created_at")]
                    public long? CreatedAt { init; get; }
                    [JsonPropertyName("updated_at")]
                    public long? UpdatedAt { init; get; }
                }
                public class EArchiveLinks {
                    [JsonPropertyName("self")]
                    public string Self { init; get; }
                }
                public class EArchiveRelationships {
                    [JsonPropertyName("sales_invoice")]
                    public EArchiveSalesInvoice SalesInvoice { get; set; }
                }
                public class EArchiveSalesInvoice {
                    [JsonPropertyName("data")]
                    public EArchiveSalesInvoiceData Data { init; get; }
                }
                public class EArchiveSalesInvoiceData {
                    [JsonPropertyName("id")]
                    public string Id { init; get; }
                    [JsonPropertyName("type")]
                    public string Type { init; get; }
                }
            }
            public class EInvoice : Response {
                [JsonPropertyName("errors")]
                public List<ResponseError> Errors { init; get; }
                [JsonPropertyName("data")]
                public EInvoiceData Data { init; get; }
            }
            public class EInvoiceData : EInvoice {
                [JsonPropertyName("id")]
                public string Id { init; get; }
                [JsonPropertyName("type")]
                public string Type { init; get; }
                [JsonPropertyName("attributes")]
                public EInvoiceAttributes Attributes { init; get; }
                [JsonPropertyName("relationships")]
                public EInvoiceRelationships Relationships { init; get; }
                [JsonPropertyName("links")]
                public EInvoiceLinks Links { init; get; }
                public class EInvoiceAttributes {
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
                    public long? CreatedAt { init; get; }
                    [JsonPropertyName("updated_at")]
                    public long? UpdatedAt { init; get; }
                }
                public class EInvoiceLinks {
                    [JsonPropertyName("self")]
                    public string Self { init; get; }
                }
                public class EInvoiceRelationships {
                    [JsonPropertyName("invoice")]
                    public EInvoiceInvoice Invoice { get; set; }
                }
                public class EInvoiceInvoice {
                    [JsonPropertyName("data")]
                    public EInvoiceInvoiceData Data { init; get; }
                }
                public class EInvoiceInvoiceData {
                    [JsonPropertyName("id")]
                    public string Id { init; get; }
                    [JsonPropertyName("type")]
                    public string Type { init; get; }
                }
            }
            public class EArchivePDF : Response {
                [JsonPropertyName("errors")]
                public List<ResponseError> Errors { init; get; }
                [JsonPropertyName("data")]
                public EArchivePDFData Data { init; get; }
            }
            public class EArchivePDFData : EArchivePDF {
                [JsonPropertyName("id")]
                public string Id { init; get; }
                [JsonPropertyName("type")]
                public string Type { init; get; }
                [JsonPropertyName("attributes")]
                public EArchivePDFAttributes Attributes { init; get; }
                public class EArchivePDFAttributes {
                    [JsonPropertyName("url")]
                    public string Url { init; get; }
                    [JsonPropertyName("expires_at")]
                    public string ExpiresAt { init; get; }
                }
            }
            public class EInvoicePDF : Response {
                [JsonPropertyName("errors")]
                public List<ResponseError> Errors { init; get; }
                [JsonPropertyName("data")]
                public EInvoicePDFData Data { init; get; }
            }
            public class EInvoicePDFData : EInvoicePDF {
                [JsonPropertyName("id")]
                public string Id { init; get; }
                [JsonPropertyName("type")]
                public string Type { init; get; }
                [JsonPropertyName("attributes")]
                public EInvoicePDFAttributes Attributes { init; get; }
                public class EInvoicePDFAttributes {
                    [JsonPropertyName("url")]
                    public string Url { init; get; }
                    [JsonPropertyName("expires_at")]
                    public string ExpiresAt { init; get; }
                }
            }
            public class EInvoiceInboxes : Response {
                [JsonPropertyName("errors")]
                public List<ResponseError> Errors { init; get; }
                [JsonPropertyName("data")]
                public List<EInvoiceInboxesData> Data { init; get; }
            }
            public class EInvoiceInboxesData : EInvoiceInboxes {
                [JsonPropertyName("id")]
                public string Id { init; get; }
                [JsonPropertyName("type")]
                public string Type { init; get; }
                [JsonPropertyName("attributes")]
                public EInvoiceInboxesAttributes Attributes { init; get; }
                public class EInvoiceInboxesAttributes {
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
            public class TrackableJob : Response {
                [JsonPropertyName("errors")]
                public List<ResponseError> Errors { init; get; }
                [JsonPropertyName("data")]
                public TrackableJobData Data { init; get; }
            }
            public class TrackableJobData : TrackableJob {
                [JsonPropertyName("id")]
                public string Id { init; get; }
                [JsonPropertyName("type")]
                public string Type { init; get; }
                [JsonPropertyName("attributes")]
                public TrackableJobAttributes Attributes { init; get; }
                public class TrackableJobAttributes {
                    [JsonPropertyName("status")]
                    public string Status { init; get; }
                    [JsonPropertyName("errors")]
                    public string[] Errors { init; get; }
                }
            }
            public class ResponseError {
                [JsonPropertyName("title")]
                public string Title { init; get; }
                [JsonPropertyName("detail")]
                public string Detail { init; get; }
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
        public bool Authentication() {
            var http = new HttpClient();
            var data = new Request.Authentication { ClientId = ClientId, ClientSecret = ClientSecret, Username = Username, Password = Password, GrantType = "password", RedirectURI = "urn:ietf:wg:oauth:2.0:oob" };
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.parasut.com/oauth/token") { Content = new StringContent(QueryString(data), Encoding.UTF8, "application/x-www-form-urlencoded") };
            var response = http.Send(request);
            var result = JsonSerializer.Deserialize<Response.Authentication>(response.Content.ReadAsStream());
            if (result.Errors != null) {
                Console.WriteLine(JsonString<Response.Authentication>(result));
                return false;
            } else {
                Token = result.AccessToken;
                return true;
            }
        }
        public Response.Contacts SearchContact(Request.Contact search) {
            var query = new NameValueCollection();
            if (!string.IsNullOrEmpty(search.Data.Attributes.TaxNumber)) {
                query.Add("filter[tax_number]", search.Data.Attributes.TaxNumber);
            }
            query.Add("include", "category,contact_portal,contact_people");
            var http = new HttpClient() { DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", Token) } };
            var request = new HttpRequestMessage(HttpMethod.Get, Endpoint + CompanyId + "/contacts" + (query.HasKeys() ? ("?" + query.ToString()) : string.Empty));
            var response = http.Send(request);
            var result = JsonSerializer.Deserialize<Response.Contacts>(response.Content.ReadAsStream());
            return result;
        }
        public Response.Contact CreateContact(Request.Contact contact) {
            var http = new HttpClient() { DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", Token) } };
            var request = new HttpRequestMessage(HttpMethod.Post, Endpoint + CompanyId + "/contacts?include=category,contact_portal,contact_people") { Content = new StringContent(JsonString(contact), Encoding.UTF8, MediaTypeNames.Application.Json) };
            var response = http.Send(request);
            var result = JsonSerializer.Deserialize<Response.Contact>(response.Content.ReadAsStream());
            return result;
        }
        public Response.Contact ShowContact(string id) {
            var http = new HttpClient() { DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", Token) } };
            var request = new HttpRequestMessage(HttpMethod.Get, Endpoint + CompanyId + "/contacts/" + id + "?include=category,contact_portal,contact_people");
            var response = http.Send(request);
            var result = JsonSerializer.Deserialize<Response.Contact>(response.Content.ReadAsStream());
            return result;
        }
        public Response.Contact DeleteContact(string id) {
            var http = new HttpClient() { DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", Token) } };
            var request = new HttpRequestMessage(HttpMethod.Delete, Endpoint + CompanyId + "/contacts/" + id);
            var response = http.Send(request);
            var result = JsonSerializer.Deserialize<Response.Contact>(response.Content.ReadAsStream());
            return result;
        }
        public Response.SalesInvoice CreateSalesInvoice(Request.SalesInvoice invoice) {
            var http = new HttpClient() { DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", Token) } };
            var request = new HttpRequestMessage(HttpMethod.Post, Endpoint + CompanyId + "/sales_invoices?include=category,contact,details,payments,tags,sharings,recurrence_plan,active_e_document") { Content = new StringContent(JsonString(invoice), Encoding.UTF8, MediaTypeNames.Application.Json) };
            var response = http.Send(request);
            var result = JsonSerializer.Deserialize<Response.SalesInvoice>(response.Content.ReadAsStream());
            return result;
        }
        public Response.SalesInvoice ShowSalesInvoice(string id) {
            var http = new HttpClient() { DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", Token) } };
            var request = new HttpRequestMessage(HttpMethod.Get, Endpoint + CompanyId + "/sales_invoices/" + id + "?include=category,contact,details,payments,tags,sharings,recurrence_plan,active_e_document");
            var response = http.Send(request);
            var result = JsonSerializer.Deserialize<Response.SalesInvoice>(response.Content.ReadAsStream());
            return result;
        }
        public Response.SalesInvoice DeleteSalesInvoice(string id) {
            var http = new HttpClient() { DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", Token) } };
            var request = new HttpRequestMessage(HttpMethod.Delete, Endpoint + CompanyId + "/sales_invoices/" + id);
            var response = http.Send(request);
            var result = JsonSerializer.Deserialize<Response.SalesInvoice>(response.Content.ReadAsStream());
            return result;
        }
        public Response.SalesInvoice CancelSalesInvoice(string id) {
            var http = new HttpClient() { DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", Token) } };
            var request = new HttpRequestMessage(HttpMethod.Delete, Endpoint + CompanyId + "/sales_invoices/" + id + "/cancel");
            var response = http.Send(request);
            var result = JsonSerializer.Deserialize<Response.SalesInvoice>(response.Content.ReadAsStream());
            return result;
        }
        public Response.SalesInvoice RecoverSalesInvoice(string id) {
            var http = new HttpClient() { DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", Token) } };
            var request = new HttpRequestMessage(HttpMethod.Patch, Endpoint + CompanyId + "/sales_invoices/" + id + "/recover");
            var response = http.Send(request);
            var result = JsonSerializer.Deserialize<Response.SalesInvoice>(response.Content.ReadAsStream());
            return result;
        }
        public Response.SalesInvoice ArchiveSalesInvoice(string id) {
            var http = new HttpClient() { DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", Token) } };
            var request = new HttpRequestMessage(HttpMethod.Patch, Endpoint + CompanyId + "/sales_invoices/" + id + "/archive");
            var response = http.Send(request);
            var result = JsonSerializer.Deserialize<Response.SalesInvoice>(response.Content.ReadAsStream());
            return result;
        }
        public Response.SalesInvoice UnarchiveSalesInvoice(string id) {
            var http = new HttpClient() { DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", Token) } };
            var request = new HttpRequestMessage(HttpMethod.Patch, Endpoint + CompanyId + "/sales_invoices/" + id + "/unarchive");
            var response = http.Send(request);
            var result = JsonSerializer.Deserialize<Response.SalesInvoice>(response.Content.ReadAsStream());
            return result;
        }
        public Response.SalesInvoice ConvertSalesInvoice(string id) {
            var http = new HttpClient() { DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", Token) } };
            var request = new HttpRequestMessage(HttpMethod.Patch, Endpoint + CompanyId + "/sales_invoices/" + id + "/convert_to_invoice");
            var response = http.Send(request);
            var result = JsonSerializer.Deserialize<Response.SalesInvoice>(response.Content.ReadAsStream());
            return result;
        }
        public Response.EArchive CreateEArchive(Request.EArchive earchive) {
            var http = new HttpClient() { DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", Token) } };
            var request = new HttpRequestMessage(HttpMethod.Post, Endpoint + CompanyId + "/e_archives") { Content = new StringContent(JsonString(earchive), Encoding.UTF8, MediaTypeNames.Application.Json) };
            var response = http.Send(request);
            var result = JsonSerializer.Deserialize<Response.EArchive>(response.Content.ReadAsStream());
            return result;
        }
        public Response.EInvoice CreateEInvoice(Request.EInvoice einvoice) {
            var http = new HttpClient() { DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", Token) } };
            var request = new HttpRequestMessage(HttpMethod.Post, Endpoint + CompanyId + "/e_invoices") { Content = new StringContent(JsonString(einvoice), Encoding.UTF8, MediaTypeNames.Application.Json) };
            var response = http.Send(request);
            var result = JsonSerializer.Deserialize<Response.EInvoice>(response.Content.ReadAsStream());
            return result;
        }
        public Response.EArchive ShowEArchive(string id) {
            var http = new HttpClient() { DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", Token) } };
            var request = new HttpRequestMessage(HttpMethod.Get, Endpoint + CompanyId + "/e_archives/" + id);
            var response = http.Send(request);
            var result = JsonSerializer.Deserialize<Response.EArchive>(response.Content.ReadAsStream());
            return result;
        }
        public Response.EInvoice ShowEInvoice(string id) {
            var http = new HttpClient() { DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", Token) } };
            var request = new HttpRequestMessage(HttpMethod.Get, Endpoint + CompanyId + "/e_invoices/" + id);
            var response = http.Send(request);
            var result = JsonSerializer.Deserialize<Response.EInvoice>(response.Content.ReadAsStream());
            return result;
        }
        public Response.EArchivePDF ShowEArchivePDF(string id) {
            var http = new HttpClient() { DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", Token) } };
            var request = new HttpRequestMessage(HttpMethod.Get, Endpoint + CompanyId + "/e_archives/" + id + "/pdf");
            var response = http.Send(request);
            var result = JsonSerializer.Deserialize<Response.EArchivePDF>(response.Content.ReadAsStream());
            return result;
        }
        public Response.EInvoicePDF ShowEInvoicePDF(string id) {
            var http = new HttpClient() { DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", Token) } };
            var request = new HttpRequestMessage(HttpMethod.Get, Endpoint + CompanyId + "/e_invoices/" + id + "/pdf");
            var response = http.Send(request);
            var result = JsonSerializer.Deserialize<Response.EInvoicePDF>(response.Content.ReadAsStream());
            return result;
        }
        public Response.EInvoiceInboxes ListEInvoiceInboxes(string vkn) {
            var http = new HttpClient() { DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", Token) } };
            var request = new HttpRequestMessage(HttpMethod.Get, Endpoint + CompanyId + "/e_invoice_inboxes?filter[vkn]=" + vkn);
            var response = http.Send(request);
            var result = JsonSerializer.Deserialize<Response.EInvoiceInboxes>(response.Content.ReadAsStream());
            return result;
        }
        public Response.TrackableJob TrackJob(string id) {
            var http = new HttpClient() { DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", Token) } };
            var request = new HttpRequestMessage(HttpMethod.Get, Endpoint + CompanyId + "/trackable_jobs/" + id);
            var response = http.Send(request);
            var result = JsonSerializer.Deserialize<Response.TrackableJob>(response.Content.ReadAsStream());
            return result;
        }
        public static string QueryString<T>(T data) where T : class {
            return string.Join("&", typeof(T).GetProperties().Where(p => p.GetValue(data, null) != null).Select(p => $"{p.GetCustomAttribute<JsonPropertyNameAttribute>().Name}={p.GetValue(data)}"));
        }
        public static string JsonString<T>(T data) where T : class {
            return JsonSerializer.Serialize(data, new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, WriteIndented = true });
        }
    }
}