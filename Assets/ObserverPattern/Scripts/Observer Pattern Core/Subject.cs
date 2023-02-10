using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Observer_Pattern
{
    public abstract class Subject : MonoBehaviour
    {
        private readonly List<IObserver> _observers = new();

        public void AddObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }
        
        [Button("Notify")]
        protected void NotifyObservers(EObserverActions action)
        {
            foreach (var observer in _observers)
            {
                observer.OnNotify(action);
            }
        }
    }
}
