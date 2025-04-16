using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxually.TechnicalTest;
using NSubstitute;
using Taxually.TechnicalTest.Handlers;
using Taxually.TechnicalTest.Interfaces;

namespace Taxually.TechnicalTest.UnitTests.Builders
{
    internal class VatRegistrationCommandHandlerBuilder
    {

        internal VatRegistrationCommandHandler Build()
        {
            return new VatRegistrationCommandHandler();
        }
    }
}
