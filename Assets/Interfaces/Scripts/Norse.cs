using UnityEngine;

namespace Interfaces
{
    public class Norse : Gods, IGods
    {
        public void PrintAllFatherName()
        {
            Debug.Log("Odin");
        }

        protected void NameOneGod()
        {
            Debug.Log("Thor");
        }
    }
}