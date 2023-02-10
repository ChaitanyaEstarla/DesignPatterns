using Observer_Pattern;

namespace ObserverPattern
{
    public class Main : Subject
    {
        private void Nuke()
        {
            NotifyObservers(EObserverActions.Nuke);
        }

        private void War()
        {
            NotifyObservers(EObserverActions.War);
        }
    
        private void Start()
        {
            Nuke();
            War();
        }
    }
}
