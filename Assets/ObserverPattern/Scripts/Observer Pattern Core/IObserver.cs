namespace Observer_Pattern
{
    public interface IObserver
    {
        public void OnNotify(EObserverActions action);
    }
}
