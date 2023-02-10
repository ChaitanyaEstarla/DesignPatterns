using System;
using System.Collections.Generic;
using Observer_Pattern;
using UnityEngine;

namespace ObserverPattern
{
    public class Observer : MonoBehaviour, IObserver
    {
        [SerializeField] private Subject subject;

        private Dictionary<EObserverActions, Action> _playerActionHandler;
    
        private void Awake()
        {
            _playerActionHandler = new Dictionary<EObserverActions, Action>
            {
                {EObserverActions.Nuke, OnNuke },
                {EObserverActions.War, OnWar }
            };
        }

        private void OnEnable()
        {
            subject.AddObserver(this);
        }

        private void OnDisable()
        {
            subject.RemoveObserver(this);
        }

        public void OnNotify(EObserverActions action)
        {
            if (_playerActionHandler.ContainsKey(action))
            {
                _playerActionHandler[action]();
            }
        }

        private void OnNuke()
        {
            Debug.LogError("Notified : Nuke");
        }

        private void OnWar()
        {
            Debug.LogError("Notified : War");
        }
    }
}
