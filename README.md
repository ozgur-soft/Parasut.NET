[![license](https://img.shields.io/:license-mit-blue.svg)](https://github.com/ozgur-soft/Parasut.NET/blob/main/LICENSE.md)

# Parasut.NET
An easy-to-use parasut.com API (v4) with .NET

# Installation
```bash
dotnet add package Parasut --version 1.0.1
```

# Create Contact
```c#
namespace Parasut {
    internal class Program {
        static void Main(string[] args) {
            var parasut = new Parasut();
            parasut.SetCompanyId("API company id");
            parasut.SetClientId("API client id");
            parasut.SetClientSecret("API client secret");
            parasut.SetUsername("API username");
            parasut.SetPassword("API password");
            parasut.Authentication(); // required
            var contact = new Parasut.Request.Contact {
                Data = new() {
                    Attributes = new() {
                        // "customer" (Müşteri) || "supplier" (Tedarikçi)
                        AccountType = "",
                        // "company" (Şirket) || "person" (Şahıs)
                        ContactType = "",
                        // Müşteri Adı
                        Name = "",
                        // Kısa isim            
                        ShortName = "",
                        // Vergi numarası         
                        TaxNumber = "",
                        // Vergi dairesi
                        TaxOffice = "",
                        // Ülke
                        Country = "",
                        // İl   
                        City = "",
                        // İlçe        
                        District = "",
                        // Adres
                        Address = "",
                        // Telefon
                        Phone = "",
                        // Faks    
                        Fax = "",
                        //  E-posta adresi
                        Email = "",
                        // IBAN numarası
                        IBAN = "",
                    }
                }
            };
            var response = parasut.CreateContact(contact);
            Console.WriteLine(Parasut.JsonString<Parasut.Response.Contact>(response));
        }
    }
}
```

# Create Sales Invoice
```c#
namespace Parasut {
    internal class Program {
        static void Main(string[] args) {
            var parasut = new Parasut();
            parasut.SetCompanyId("API company id");
            parasut.SetClientId("API client id");
            parasut.SetClientSecret("API client secret");
            parasut.SetUsername("API username");
            parasut.SetPassword("API password");
            parasut.Authentication(); // required
            var invoice = new Parasut.Request.SalesInvoice {
                Data = new() {
                    Attributes = new() {
                        // Fatura türü: "invoice", "export", "estimate", "cancelled", "recurring_invoice", "recurring_estimate", "recurring_export", "refund"
                        ItemType = "invoice",
                        // Fatura tarihi
                        IssueDate = new DateTime(2020, 02, 20).ToString("yyyy-MM-dd"),
                        // Fatura açıklaması
                        Description = "",
                        // Vergi numarası
                        TaxNumber = "11111111111",
                        // Vergi dairesi
                        TaxOffice = "",
                        // Ülke
                        Country = "",
                        // İl   
                        City = "",
                        // İlçe        
                        District = "",
                        // Adres
                        BillingAddress = "",
                        // Telefon
                        BillingPhone = "",
                        // Faks    
                        BillingFax = "",
                        // Para birimi : "TRL", "USD", "EUR", "GBP"
                        Currency = "TRL"
                    },
                    Relationships = new() {
                        Contact = new() {
                            Data = new() {
                                // Paraşüt Müşteri ID (varsa)
                                Id = ""
                            }
                        },
                        Details = new() {
                            Data = new Parasut.Request.SalesInvoiceData.SalesInvoiceDetailsData[] {
                                new(){
                                    Attributes = new() {
                                        // Ürün miktarı
                                        Quantity = "1",
                                        // Ürün birim fiyatı
                                        UnitPrice = (100 / 1.18).ToString("N4", Globalization.CultureInfo.InvariantCulture), // 100 TL için kdv hariç fiyat formatı
                                        // Ürün KDV oranı
                                        VatRate = "18"
                                    },
                                    Relationships = new() {
                                        Product = new() {
                                            Data = new() {
                                                // Paraşüt Ürün ID (varsa)
                                                Id = ""
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
            var response = parasut.CreateSalesInvoice(invoice);
            Console.WriteLine(Parasut.JsonString<Parasut.Response.SalesInvoice>(response));
        }
    }
}
```

# Get the PDF url of the invoice
```c#
namespace Parasut {
    internal class Program {
        static void Main(string[] args) {
            var parasut = new Parasut();
            parasut.SetCompanyId("API company id");
            parasut.SetClientId("API client id");
            parasut.SetClientSecret("API client secret");
            parasut.SetUsername("API username");
            parasut.SetPassword("API password");
            parasut.Authentication(); // required
            var invoice = parasut.ShowSalesInvoice("Invoice ID");
            if (invoice.Data != null) {
                switch (invoice.Data.Relationships.ActiveEDocument.Data.Type) {
                    case "e_invoices":
                        var einvoice = parasut.ShowEInvoicePDF(invoice.Data.Relationships.ActiveEDocument.Data.Id);
                        Console.WriteLine(einvoice.Data.Attributes.Url);
                        break;
                    case "e_archives":
                        var earchive = parasut.ShowEArchivePDF(invoice.Data.Relationships.ActiveEDocument.Data.Id);
                        Console.WriteLine(earchive.Data.Attributes.Url);
                        break;
                }
            }
        }
    }
}
```
