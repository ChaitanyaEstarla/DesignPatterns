using UnityEngine;

namespace FactoryPattern
{
    public class Main : MonoBehaviour
    {
        private void Start()
        {
            new Client().Main();
        }
    }
}