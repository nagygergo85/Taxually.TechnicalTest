namespace Taxually.TechnicalTest;

public record VatRegistrationResponseDto(
    bool IsSuccess,
    string Message,
    Exception? Error = default);
