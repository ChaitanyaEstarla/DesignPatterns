using UnityEngine;

namespace FactoryPattern
{
    class Client
    {
        public void Main()
        {
            ClientCode(new CreatorOne());
        }

        private void ClientCode(ACreator creator)
        {
            Debug.Log("Client Code: " + creator.SomeOperation());
        }
    }
}
