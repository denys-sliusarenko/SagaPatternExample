using SagaPatternExample.Steps;

namespace SagaPatternExample.Unit.Tests;

public class MockStep(string executeMessage, string compensateMessage, bool fail = false) : ISagaStep
{
    private readonly string _executeMessage = executeMessage;
    private readonly string _compensateMessage = compensateMessage;
    private readonly bool _fail = fail;

    public Task ExecuteAsync()
    {
        if (_fail) throw new InvalidOperationException("Step failed");
        Console.WriteLine(_executeMessage);
        return Task.CompletedTask;
    }

    public Task CompensateAsync()
    {
        Console.WriteLine(_compensateMessage);
        return Task.CompletedTask;
    }
}

