using SagaPatternExample.Steps;

namespace SagaPatternExample.Unit.Tests.Steps;

public class PaymentStepTests
{
    [Fact]
    public async Task ExecuteAsync_Should_Write_WriteOffMessage()
    {
        // Arrange
        var paymentStep = new PaymentStep();
        using var sw = new StringWriter();
        Console.SetOut(sw);

        // Act
        await paymentStep.ExecuteAsync();

        // Assert
        var output = sw.ToString().Trim();
        Assert.Equal("Write-off of funds", output);
    }

    [Fact]
    public async Task CompensateAsync_Should_Write_RefundMessage()
    {
        // Arrange
        var paymentStep = new PaymentStep();
        using var sw = new StringWriter();
        Console.SetOut(sw);

        // Act
        await paymentStep.CompensateAsync();

        // Assert
        var output = sw.ToString().Trim();
        Assert.Equal("Refund", output);
    }
}
