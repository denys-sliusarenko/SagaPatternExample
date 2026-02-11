namespace SagaPatternExample.Unit.Tests
{
    public class ConsoleCapture : IDisposable
    {
        private readonly TextWriter _originalOut;
        public StringWriter Output { get; }

        public ConsoleCapture()
        {
            _originalOut = Console.Out;
            Output = new StringWriter();
            Console.SetOut(Output);
        }

        public void Dispose()
        {
            Console.SetOut(_originalOut);
        }
    }

}
