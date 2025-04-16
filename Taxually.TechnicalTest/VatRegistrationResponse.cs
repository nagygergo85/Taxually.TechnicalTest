namespace Taxually.TechnicalTest;

public class VatRegistrationResponse
{
    public VatRegistrationResponse(bool isSuccess, string message)
    {
        IsSuccess = isSuccess;
        Message = message;
    }

    public bool IsSuccess { get; set; }

    public string Message { get; set; }
}