using Taxually.TechnicalTest.Interfaces;

namespace Taxually.TechnicalTest.VatRegistrars;

public class GreatBritainVatRegistrar: IVatRegistrar
{
    public async Task RegisterForVatNumber(VatRegistrationRequest vatRegistrationRequest)
    {
        // UK has an API to register for a VAT number
        var httpClient = new TaxuallyHttpClient();
        await httpClient.PostAsync("https://api.uktax.gov.uk", vatRegistrationRequest);
    }
}