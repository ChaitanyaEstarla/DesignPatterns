namespace CommandPattern
{
    public class ComplexCommand : ICommand
    {
        private readonly Receiver _receiver;
        
        private readonly string _one;
        private readonly string _two;
        
        public ComplexCommand(Receiver receiver, string one, string two)
        {
            _one = one;
            _two = two;
            _receiver = receiver;
        }

        public void Execute()
        {
            _receiver.DoSomething(_one);
            _receiver.DoSomethingElse(_two);
        }
    }
}