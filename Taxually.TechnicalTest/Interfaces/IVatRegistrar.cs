namespace Taxually.TechnicalTest.Interfaces;

public interface IVatRegistrar
{
    public Task RegisterForVatNumber(VatRegistrationRequest vatRegistrationRequest);
}