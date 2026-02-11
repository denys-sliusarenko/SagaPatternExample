namespace SagaPatternExample.Steps;

public class PaymentStep : ISagaStep
{
    public async Task ExecuteAsync()
    {
        Console.WriteLine("Write-off of funds");
        await Task.Delay(200);
    }

    public async Task CompensateAsync()
    {
        Console.WriteLine("Refund");
        await Task.Delay(200);
    }
}
