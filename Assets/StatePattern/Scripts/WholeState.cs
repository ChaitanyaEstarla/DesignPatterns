using UnityEngine;

namespace StatePattern
{
    public class WholeState : ObjectBaseState
    {
        public override void EnterState(ObjectStateManager item)
        {
            Debug.Log("Whole State");
        }

        public override void UpdateState(ObjectStateManager item)
        {
            
        }

        public override void OnCollisionEnter(ObjectStateManager item)
        {
            
        }
    }
}
