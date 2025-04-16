using MediatR;

namespace Taxually.TechnicalTest;

public class VatRegistrationRequest : IRequest<VatRegistrationResponse>
{
    //public VatRegistrationRequest(){}

    public VatRegistrationRequest(VatRegistrationRequestDto vatRegistrationRequestDto)
    {
        CompanyName = vatRegistrationRequestDto.CompanyName;
        CompanyId = vatRegistrationRequestDto.CompanyId;
        Country = vatRegistrationRequestDto.Country;
    }

    public string CompanyName { get; set; }
    public string CompanyId { get; set; }
    public string Country { get; set; }
}