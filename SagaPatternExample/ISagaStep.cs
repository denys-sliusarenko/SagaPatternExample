namespace SagaPatternExample;

public interface ISagaStep
{
    Task ExecuteAsync();
    Task CompensateAsync();
}
