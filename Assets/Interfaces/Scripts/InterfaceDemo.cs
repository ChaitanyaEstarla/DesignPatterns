using UnityEngine;

namespace Interfaces
{
    public class InterfaceDemo : MonoBehaviour
    {
        private readonly IGods _greek = new Greek();
        private readonly IGods _norse = new Norse();

        private void Start()
        {
            _greek.PrintAllFatherName();
            _norse.PrintAllFatherName();
        }
    }
}
