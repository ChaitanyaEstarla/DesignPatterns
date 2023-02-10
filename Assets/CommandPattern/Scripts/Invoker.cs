namespace CommandPattern
{
    public class Invoker
    {
        private ICommand _onStart;
        private ICommand _onFinish;

        public void SetOnStart(ICommand command)
        {
            _onStart = command;
        }
        
        public void SetOnFinish(ICommand command)
        {
            _onFinish = command;
        }

        public void DoSomethingImportant()
        {
            _onStart?.Execute();
            _onFinish?.Execute();
        }
        
    }
}