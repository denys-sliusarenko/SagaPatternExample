namespace SagaPatternExample;

public class SagaOrchestrator
{
    private readonly List<ISagaStep> _steps = [];

    public void AddStep(ISagaStep step) => _steps.Add(step);

    public async Task ExecuteAsync()
    {
        var completedSteps = new Stack<ISagaStep>();

        try
        {
            foreach (var step in _steps)
            {
                await step.ExecuteAsync();
                completedSteps.Push(step);
            }

            Console.WriteLine("Saga completed successfully");
        }
        catch
        {
            Console.WriteLine("Error: Starting compensations");

            while (completedSteps.Count != 0)
            {
                await completedSteps.Pop().CompensateAsync();
            }

            throw;
        }
    }
}
