[![license](https://img.shields.io/:license-mit-blue.svg)](https://github.com/ozgur-soft/Parasut.NET/blob/main/LICENSE.md)

# Parasut.NET
An easy-to-use parasut.com API (v4) with .NET

# Installation
```bash
dotnet add package Parasut --version 1.0.1
```

# Get the PDF url of the invoice
```c#
using Parasut;

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
            return Redirect(einvoice.Attributes.Url);
        case "e_archives":
            var earchive = parasut.ShowEArchivePDF(invoice.Relationships.ActiveEDocument.Data.Id);
            System.Console.WriteLine(earchive.Attributes.Url);
    }
}
```
