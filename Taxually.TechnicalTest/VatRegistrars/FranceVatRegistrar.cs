using System.Text;
using Taxually.TechnicalTest.Interfaces;

namespace Taxually.TechnicalTest.VatRegistrars;

public class FranceVatRegistrar: IVatRegistrar
{
    public async Task RegisterForVatNumber(VatRegistrationRequest vatRegistrationRequest)
    {
        // France requires an excel spreadsheet to be uploaded to register for a VAT number
        var csvBuilder = new StringBuilder();
        csvBuilder.AppendLine("CompanyName,CompanyId");
        csvBuilder.AppendLine($"{vatRegistrationRequest.CompanyName}{vatRegistrationRequest.CompanyId}");
        var csv = Encoding.UTF8.GetBytes(csvBuilder.ToString());
        var excelQueueClient = new TaxuallyQueueClient();
        // Queue file to be processed
        await excelQueueClient.EnqueueAsync("vat-registration-csv", csv);
    }
}