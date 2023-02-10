using UnityEngine;

namespace Interfaces
{
    public class Greek : Gods, IGods
    {
        public void PrintAllFatherName()
        {
            Debug.Log("Zeus");
        }

        protected void NameOneGod()
        {
            Debug.Log("Poseidon");
        }
    }
}