using SagaPatternExample.Steps;

namespace SagaPatternExample.Unit.Tests.Steps;

[Collection("Sequential")]

public class PaymentStepTests
{
    [Fact]
    public async Task ExecuteAsync_Should_Write_WriteOffMessage()
    {
        // Arrange
        var paymentStep = new PaymentStep();
        using var console = new ConsoleCapture();

        // Act
        await paymentStep.ExecuteAsync();

        // Assert
        Assert.Equal("Write-off of funds", console.Output.ToString().Trim());
    }

    [Fact]
    public async Task CompensateAsync_Should_Write_RefundMessage()
    {
        // Arrange
        var paymentStep = new PaymentStep();
        using var console = new ConsoleCapture();

        // Act
        await paymentStep.CompensateAsync();

        // Assert
        Assert.Equal("Refund", console.Output.ToString().Trim());
    }
}
