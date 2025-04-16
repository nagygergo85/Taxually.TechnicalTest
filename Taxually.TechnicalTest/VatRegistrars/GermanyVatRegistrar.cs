using System.Xml.Serialization;
using Taxually.TechnicalTest.Interfaces;

namespace Taxually.TechnicalTest.VatRegistrars;

public class GermanyVatRegistrar: IVatRegistrar
{
    public async Task RegisterForVatNumber(VatRegistrationRequest vatRegistrationRequest)
    {
        // Germany requires an XML document to be uploaded to register for a VAT number
        using (var stringwriter = new StringWriter())
        {
            var serializer = new XmlSerializer(typeof(VatRegistrationRequest));
            serializer.Serialize(stringwriter, vatRegistrationRequest);
            var xml = stringwriter.ToString();
            var xmlQueueClient = new TaxuallyQueueClient();
            // Queue xml doc to be processed
            await xmlQueueClient.EnqueueAsync("vat-registration-xml", xml);
        }
    }
}