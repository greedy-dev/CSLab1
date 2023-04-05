namespace Lab1.Utilities;

public class OperationResult
{
    public bool IsSuccess { get; }
    public string ErrorMessage { get; }

    public OperationResult(bool isSuccess, string errorMessage)
    {
        IsSuccess = isSuccess;
        ErrorMessage = errorMessage;
    }
}
