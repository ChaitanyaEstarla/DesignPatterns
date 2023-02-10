namespace StatePattern
{
    public abstract class ObjectBaseState
    {
        public abstract void EnterState(ObjectStateManager item);
        public abstract void UpdateState(ObjectStateManager item);
        public abstract void OnCollisionEnter(ObjectStateManager item);
    }
}
