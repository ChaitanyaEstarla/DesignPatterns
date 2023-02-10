using UnityEngine;

namespace StatePattern
{
    public class ObjectStateManager : MonoBehaviour
    {
        private ObjectBaseState _currentState;
        public RottenState RottenState = new RottenState();
        public ChewedState ChewedState = new ChewedState();
        public GrowingState GrowingState = new GrowingState();
        public WholeState WholeState = new WholeState();

        private void Start()
        {
            _currentState = GrowingState;
            _currentState.EnterState(this);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _currentState.UpdateState(this);
            }
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public void ChangeState(ObjectBaseState item)
        {
            _currentState = item;
            _currentState.EnterState(this);
        }
    }
}
