namespace SagaPatternExample.Steps;

public interface ISagaStep
{
    Task ExecuteAsync();
    Task CompensateAsync();
}
