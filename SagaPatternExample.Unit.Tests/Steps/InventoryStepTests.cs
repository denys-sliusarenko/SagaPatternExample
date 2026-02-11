using SagaPatternExample.Steps;

namespace SagaPatternExample.Unit.Tests.Steps;

public class InventoryStepTests
{
    [Fact]
    public async Task ExecuteAsync_Should_Write_ProductReservation()
    {
        // Arrange
        var inventoryStep = new InventoryStep();
        using var console = new ConsoleCapture();

        // Act
        await inventoryStep.ExecuteAsync();

        // Assert
        Assert.Equal("Product reservation", console.Output.ToString().Trim());
    }

    [Fact]
    public async Task CompensateAsync_Should_Write_CancellationOfReservation()
    {
        // Arrange
        var inventoryStep = new InventoryStep();
        using var console = new ConsoleCapture();

        // Act
        await inventoryStep.CompensateAsync();

        // Assert
        Assert.Equal("Cancellation of reservation", console.Output.ToString().Trim());
    }
}
