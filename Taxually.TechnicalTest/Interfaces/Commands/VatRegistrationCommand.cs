using MediatR;

namespace Taxually.TechnicalTest.Interfaces.Commands;

public class VatRegistrationCommand : IRequest<VatRegistrationResponse>
{
    public VatRegistrationRequest VatRegistrationRequest { get; }

    public VatRegistrationCommand(VatRegistrationRequest vatRegistrationRequest)
    {
        VatRegistrationRequest = vatRegistrationRequest;
    }
}