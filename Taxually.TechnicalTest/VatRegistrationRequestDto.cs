namespace Taxually.TechnicalTest;

public record VatRegistrationRequestDto(
    string CompanyName,
    string CompanyId,
    string Country);