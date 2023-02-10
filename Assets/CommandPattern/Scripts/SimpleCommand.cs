using UnityEngine;

namespace CommandPattern
{
    public class SimpleCommand : ICommand
    {
        private readonly string _payload;

        public SimpleCommand(string payload)
        {
            _payload = payload;
        }
        
        public void Execute()
        {
            Debug.Log(_payload);
        }
    }
}

