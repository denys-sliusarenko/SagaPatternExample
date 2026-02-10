namespace SagaPatternExample;

public class InventoryStep : ISagaStep
{
    public async Task ExecuteAsync()
    {
        Console.WriteLine("Product reservation");
        await Task.Delay(200);
    }

    public async Task CompensateAsync()
    {
        Console.WriteLine("Cancellation of reservation");
        await Task.Delay(200);
    }
}