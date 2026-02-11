using SagaPatternExample;
using SagaPatternExample.Steps;

var saga = new SagaOrchestrator();
saga.AddStep(new PaymentStep());
saga.AddStep(new InventoryStep());

await saga.ExecuteAsync();
