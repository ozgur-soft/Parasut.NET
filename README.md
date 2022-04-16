[![license](https://img.shields.io/:license-mit-blue.svg)](https://github.com/ozgur-soft/Parasut.NET/blob/main/LICENSE.md)

# Parasut.NET
An easy-to-use parasut.com API (v4) with .NET

# Installation
```bash
dotnet add package Parasut --version 1.0.1
```

# Create Contact
```c#
using System.Text.Json;

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
                        AccountType = "customer",
                        // "company" (Şirket) || "person" (Şahıs)
                        ContactType = "person",
                        // Müşteri Adı
                        Name = "",
                        // Kısa isim            
                        ShortName = "",
                        // Vergi numarası         
                        TaxNumber = "",
                        // Vergi dairesi
                        TaxOffice = "",
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
                    },
                    Relationships = new() {
                        Category = new() {
                            Data = new() {
                                // Kategori ID (varsa)
                                Id = ""
                            }
                        }
                    }
                }
            };
            var response = parasut.CreateContact(contact);
            Console.WriteLine(Parasut.JsonString<Parasut.Response.ContactData>(response));
        }
    }
}
```

# Get the PDF url of the invoice
```c#
using System;

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
            if (invoice != null) {
                switch (invoice.Relationships.ActiveEDocument.Data.Type) {
                    case "e_invoices":
                        var einvoice = parasut.ShowEInvoicePDF(invoice.Relationships.ActiveEDocument.Data.Id);
                        Console.WriteLine(einvoice.Attributes.Url);
                        break;
                    case "e_archives":
                        var earchive = parasut.ShowEArchivePDF(invoice.Relationships.ActiveEDocument.Data.Id);
                        Console.WriteLine(earchive.Attributes.Url);
                        break;
                }
            }
        }
    }
}
```
