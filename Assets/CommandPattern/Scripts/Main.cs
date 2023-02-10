using UnityEngine;

namespace CommandPattern
{
    public class Main : MonoBehaviour
    {
        private readonly Invoker _invoker = new Invoker();
        private readonly Receiver _receiver = new Receiver();

        private void Start()
        {
            _invoker.SetOnStart(new SimpleCommand("Messenger: This is Blasphemy"));
            _invoker.SetOnFinish(new ComplexCommand(_receiver, "Messenger: Madness", "Leonidas: This is Sparta"));
            _invoker.DoSomethingImportant();
        }
    }
}