using System.Net.NetworkInformation;
using MediatR;
using Taxually.TechnicalTest.Enums;
using Taxually.TechnicalTest.Interfaces.Commands;

namespace Taxually.TechnicalTest.Handlers;

public class VatRegistrationCommandHandler : IRequestHandler<VatRegistrationCommand, VatRegistrationResponse>
{
    public async Task<VatRegistrationResponse> Handle(VatRegistrationCommand vatRegistrationCommand, CancellationToken cancellationToken)
    {
        try
        {
            var vatRegistrationRequest = vatRegistrationCommand.VatRegistrationRequest;
            var country = GetCountryFromString(vatRegistrationRequest.Country);

            var countryRegistrar = new CountryRegistrarBuilder()
                .ForCountry(country)
                .Build();

            await countryRegistrar.RegisterForVatNumber(vatRegistrationRequest);

            return new VatRegistrationResponse(
                true,
                "VAT Registration request sent successfully.");
        }
        catch (Exception ex)
        {
            //todo: log the actual exception here

            return new VatRegistrationResponse(
                false,
                $"An Error occurred while trying to register VAT number: {ex.Message}");
        }
    }

    private Country GetCountryFromString(string countryString)
    {
        return countryString switch
        {
            "FR" => Country.France,
            "GB" => Country.UnitedKingdom,
            "DE" => Country.Germany,
            _ => throw new NotSupportedException($"Country {countryString} is not supported.")
        };
    }
}