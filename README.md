[![license](https://img.shields.io/:license-mit-blue.svg)](https://github.com/ozgur-soft/Parasut.NET/blob/main/LICENSE.md)

# Parasut.NET
An easy-to-use parasut.com API (v4) with .NET

# Installation
```bash
dotnet add package Parasut --version 1.0.1
```

# Müşteri/Tedarikçi oluşturma
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
                        // "customer" (Müşteri), "supplier" (Tedarikçi)
                        AccountType = "",
                        // "company" (Şirket), "person" (Şahıs)
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

# Peşin satış faturası oluşturma
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
                        ItemType = "invoice",
                        // Fatura açıklaması
                        Description = "",
                        // Fatura tarihi (Yıl-Ay-Gün)
                        IssueDate = new DateTime(2020, 02, 20).ToString("yyyy-MM-dd"),
                        // İrsaliyeli fatura
                        ShipmentIncluded = false,
                        // Peşin satış
                        CashSale = true,
                        // Peşin ödeme tarihi (Yıl-Ay-Gün)
                        PaymentDate = new DateTime(2020, 02, 20).ToString("yyyy-MM-dd"),
                        // Peşin ödeme açıklaması
                        PaymentDescription = "",
                        // Paraşüt Banka ID (zorunlu)
                        PaymentAccountID = "",
                        // Para birimi : "TRL", "USD", "EUR", "GBP"
                        Currency = "TRL"
                    },
                    Relationships = new() {
                        Contact = new() {
                            Data = new() {
                                Id = "" // Paraşüt Müşteri ID (zorunlu)
                            }
                        },
                        Details = new() {
                            Data = new Parasut.Request.SalesInvoiceData.SalesInvoiceDetailsData[] {
                                new(){
                                    Attributes = new() {
                                        // Ürün miktarı
                                        Quantity = "1",
                                        // Ürün birim fiyatı
                                        UnitPrice = (100 / 1.18).ToString("N4", System.Globalization.CultureInfo.InvariantCulture), // 100 TL için kdv hariç fiyat formatı
                                        // Ürün KDV oranı
                                        VatRate = "18"
                                    },
                                    Relationships = new() {
                                        Product = new() {
                                            Data = new() {
                                                Id = "" // Paraşüt Ürün ID (varsa)
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

# Satış faturası resmileştirme
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
            var inboxes = parasut.ListEInvoiceInboxes("vergi numarası");
            if (inboxes.Data.Any()) { // e-Fatura ise
                foreach (var inbox in inboxes.Data) {
                    var einvoice = new Parasut.Request.EInvoice {
                        Data = new() {
                            Attributes = new() {
                                To = inbox.Attributes.EInvoiceAddress,
                                // "basic" (Temel e-Fatura) || "commercial" (Ticari e-Fatura)
                                Scenario = "basic",
                                // Fatura notu
                                Note = "",
                                // Firma KDV den muaf ise muafiyet sebebi kodu (Varsa)
                                VatExemptionReasonCode = "",
                                // Firma KDV den muaf ise muafiyet sebebi açıklaması (Varsa)
                                VatExemptionReason = "",
                                // Tevkifat oranına ait vergi kodu (Varsa)
                                VatWithholdingCode = "",
                            },
                            Relationships = new() {
                                Invoice = new() {
                                    Data = new() {
                                        Id = "" // Paraşüt Fatura ID (zorunlu)
                                    }
                                }
                            }
                        }
                    };
                    parasut.CreateEInvoice(einvoice);
                }
            } else { // e-Arşiv ise
                var earchive = new Parasut.Request.EArchive {
                    Data = new() {
                        Attributes = new() {
                            // Fatura notu
                            Note = "",
                            // Internet satışı (varsa)
                            InternetSale = new() {
                                // İnternet satışının yapıldığı url
                                Url = "",
                                // "KREDIKARTI/BANKAKARTI", "EFT/HAVALE", "KAPIDAODEME", "ODEMEARACISI" (Ödeme yöntemi)
                                PaymentType = "",
                                // Ödeme tarihi (Yıl-Ay-Gün)
                                PaymentDate = "",
                                // Ödeme platformu (iyzico,payu,banka adı vb.)
                                PaymentPlatform = ""
                            },
                            // Firma KDV den muaf ise muafiyet sebebi kodu (Varsa)
                            VatExemptionReasonCode = "",
                            // Firma KDV den muaf ise muafiyet sebebi açıklaması (Varsa)
                            VatExemptionReason = "",
                            // Tevkifat oranına ait vergi kodu (Varsa)
                            VatWithholdingCode = ""
                        },
                        Relationships = new() {
                            SalesInvoice = new() {
                                Data = new() {
                                    Id = "" // Paraşüt Fatura ID (zorunlu)
                                }
                            }
                        }
                    }
                };
                parasut.CreateEArchive(earchive);
            }
        }
    }
}
```

# E-arşiv/E-fatura pdf adresi görüntüleme
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
