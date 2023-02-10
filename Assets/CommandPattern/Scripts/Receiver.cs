using UnityEngine;

namespace CommandPattern
{
    public class Receiver
    {
        public void DoSomethingElse(string one)
        {
            Debug.Log(one);
        }

        public void DoSomething(string two)
        {
            Debug.Log(two);   
        }
    }
}