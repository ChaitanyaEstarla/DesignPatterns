using UnityEngine;

namespace StatePattern
{
    public class GrowingState : ObjectBaseState
    {
        public override void EnterState(ObjectStateManager item)
        {
            Debug.Log("Started Growing");
        }

        public override void UpdateState(ObjectStateManager item)
        {
            item.ChangeState(item.WholeState);
        }

        public override void OnCollisionEnter(ObjectStateManager item)
        {
            
        }
    }
}
