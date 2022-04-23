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
            var auth = parasut.Authentication();
            if (auth) {
                var contact = new Parasut.Request.Contact {
                    Data = new() {
                        Attributes = new() {
                            AccountType = "", // "customer" (Müşteri), "supplier" (Tedarikçi)
                            ContactType = "", // "company" (Şirket), "person" (Şahıs)
                            Name = "", // Müşteri Adı
                            ShortName = "", // Kısa isim
                            TaxNumber = "", // Vergi numarası
                            TaxOffice = "", // Vergi dairesi
                            Country = "", // Ülke
                            City = "", // İl
                            District = "", // İlçe
                            Address = "", // Adres
                            Phone = "", // Telefon
                            Fax = "", // Faks
                            Email = "", //  E-posta adresi
                            IBAN = "" // IBAN numarası
                        }
                    }
                };
                var response = parasut.CreateContact(contact);
                Console.WriteLine(Parasut.JsonString<Parasut.Response.Contact>(response));
            }
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
            var auth = parasut.Authentication();
            if (auth) {
                var invoice = new Parasut.Request.SalesInvoice {
                    Data = new() {
                        Attributes = new() {
                            ItemType = "invoice",
                            Description = "", // Fatura açıklaması
                            IssueDate = new DateTime(2022, 02, 20).ToString("yyyy-MM-dd"), // Fatura tarihi (Yıl-Ay-Gün)
                            ShipmentIncluded = false, // İrsaliyeli fatura
                            CashSale = true, // Peşin satış
                            PaymentDate = new DateTime(2022, 02, 20).ToString("yyyy-MM-dd"), // Peşin ödeme tarihi (Yıl-Ay-Gün)
                            PaymentDescription = "", // Peşin ödeme açıklaması
                            PaymentAccountID = "", // Paraşüt Banka ID (zorunlu)
                            Currency = "TRL" // Para birimi : "TRL", "USD", "EUR", "GBP"
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
                                        Quantity = "1", // Ürün miktarı
                                        UnitPrice = "1.00", // Ürün birim fiyatı (KDV hariç)
                                        VatRate = "18" // Ürün KDV oranı
                                    },
                                    Relationships = new() {
                                        Product = new() {
                                            Data = new() {
                                                Id = "" // Paraşüt Ürün ID (zorunlu)
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
            var auth = parasut.Authentication();
            if (auth) {
                var invoice = parasut.ShowSalesInvoice("Paraşüt Fatura ID");
                if (invoice != null) {
                    var inboxes = parasut.ListEInvoiceInboxes(invoice.Data.Attributes.TaxNumber);
                    if (inboxes.Data.Any()) { // e-Fatura ise
                        foreach (var inbox in inboxes.Data) {
                            var einvoice = new Parasut.Request.EInvoice {
                                Data = new() {
                                    Attributes = new() {
                                        To = inbox.Attributes.EInvoiceAddress,
                                        Scenario = "basic", // "basic" (Temel e-Fatura), "commercial" (Ticari e-Fatura)
                                        Note = "", // Fatura notu
                                    },
                                    Relationships = new() { Invoice = new() { Data = new() { Id = invoice.Data.Id } } }
                                }
                            };
                            var response = parasut.CreateEInvoice(einvoice);
                            while (true) {
                                var job = parasut.TrackJob(response.Data.Id);
                                if (job.Data.Attributes.Status != "running") {
                                    Console.WriteLine(Parasut.JsonString<Parasut.Response.TrackableJob>(job));
                                    break;
                                }
                            }
                        }
                    } else { // e-Arşiv ise
                        var earchive = new Parasut.Request.EArchive {
                            Data = new() {
                                Attributes = new() {
                                    Note = "", // Fatura notu
                                    // Internet satışı (varsa)
                                    InternetSale = new() {
                                        Url = "", // İnternet satışının yapıldığı url
                                        PaymentType = "", // Ödeme yöntemi : "KREDIKARTI/BANKAKARTI", "EFT/HAVALE", "KAPIDAODEME", "ODEMEARACISI"
                                        PaymentPlatform = "", // Ödeme platformu (iyzico,payu,banka adı vb.)
                                        PaymentDate = new DateTime(2022, 02, 20).ToString("yyyy-MM-dd"), // Ödeme tarihi (Yıl-Ay-Gün)
                                    }
                                },
                                Relationships = new() { SalesInvoice = new() { Data = new() { Id = invoice.Data.Id } } }
                            }
                        };
                        var response = parasut.CreateEArchive(earchive);
                        while (true) {
                            var job = parasut.TrackJob(response.Data.Id);
                            if (job.Data.Attributes.Status != "running") {
                                Console.WriteLine(Parasut.JsonString<Parasut.Response.TrackableJob>(job));
                                break;
                            }
                        }
                    }
                }
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
            var auth = parasut.Authentication();
            if (auth) {
                var invoice = parasut.ShowSalesInvoice("Paraşüt Fatura ID");
                if (invoice != null) {
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
}
```
