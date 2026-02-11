namespace SagaPatternExample.Unit.Tests;

[Collection("Sequential")]
public class SagaOrchestratorTests
{
    [Fact]
    public async Task ExecuteAsync_AllSteps_Success()
    {
        // Arrange
        var orchestrator = new SagaOrchestrator();
        using var console = new ConsoleCapture();

        orchestrator.AddStep(new MockStep("Step1 executed", "Step1 compensated"));
        orchestrator.AddStep(new MockStep("Step2 executed", "Step2 compensated"));

        // Act
        await orchestrator.ExecuteAsync();

        // Assert
        var output = console.Output.ToString().Trim();
        Assert.Contains("Step1 executed", output);
        Assert.Contains("Step2 executed", output);
        Assert.Contains("Saga completed successfully", output);
    }

    [Fact]
    public async Task ExecuteAsync_StepFails_TriggersCompensation()
    {
        // Arrange
        var orchestrator = new SagaOrchestrator();
        using var console = new ConsoleCapture();

        orchestrator.AddStep(new MockStep("Step1 executed", "Step1 compensated"));
        orchestrator.AddStep(new MockStep("Step2 executed", "Step2 compensated", fail: true));
        orchestrator.AddStep(new MockStep("Step3 executed", "Step3 compensated"));

        // Act & Assert
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
        {
            await orchestrator.ExecuteAsync();
        });

        var output = console.Output.ToString().Trim();
        Assert.Contains("Step1 executed", output);
        Assert.DoesNotContain("Step3 executed", output);
        Assert.Contains("Step1 compensated", output);
        Assert.Contains("Error: Starting compensations", output);
    }
}