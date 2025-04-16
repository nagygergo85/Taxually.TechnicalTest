using Taxually.TechnicalTest.Enums;
using Taxually.TechnicalTest.Interfaces;
using Taxually.TechnicalTest.VatRegistrars;

namespace Taxually.TechnicalTest;

public class CountryRegistrarBuilder
{
    private Country Country { get; set; }

    internal IVatRegistrar Build()
    {
        return Country switch
        {
            Country.France => new FranceVatRegistrar(),
            Country.Germany => new GermanyVatRegistrar(),
            Country.UnitedKingdom => new GreatBritainVatRegistrar(),
            _ => throw new NotSupportedException("Country is not supported.")
        };
    }

    internal CountryRegistrarBuilder ForCountry(Country country)
    {
        Country = country;
        return this;
    }
    
}