using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bogus;
using System.Threading.Tasks;
using Taxually.TechnicalTest.Interfaces.Commands;

namespace Taxually.TechnicalTest.UnitTests.Builders
{
    internal class VatRegistrationCommandBuilder
    {
        private string vatCountry;

        internal VatRegistrationCommandBuilder WithCountry(string country)
        {
            vatCountry = country;
            return this;
        }

        internal VatRegistrationCommand Build()
        {
            return 
                new VatRegistrationCommand(
                    new VatRegistrationRequest(
                        new VatRegistrationRequestDto(
                            new Faker().Company.CompanyName(), 
                            new Faker().Random.AlphaNumeric(10),
                            vatCountry
                        )
                    )
                );
        }
    }
}
