using SagaPatternExample;

var saga = new SagaOrchestrator();
saga.AddStep(new PaymentStep());
saga.AddStep(new InventoryStep());

await saga.ExecuteAsync();
