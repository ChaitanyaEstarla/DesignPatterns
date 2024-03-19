using System;
using System.Collections.Generic;
using Observer_Pattern;
using UnityEngine;
using UnityEngine.Events;

namespace Delegates_and_Events.Scripts
{
    public class EventManager : MonoBehaviour
    {
        #region Variables

        private Dictionary<CustomEventTriggers, CustomEvent> _typedEvents;
        private Dictionary<EObserverActions, UnityEvent> _events;
        private Dictionary<string, Action> eventDictionary;
        private static EventManager _eventManager;

        #endregion

        #region Member Functions

        /// <summary>
        /// 
        /// </summary>
        public static EventManager Instance
        {
            get
            {
                if (!_eventManager)
                {
                    _eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                    if (!_eventManager)
                        Debug.LogError("There needs to be one active EventManager script on a GameObject in your scene.");
                    else
                        _eventManager.Init();
                }

                return _eventManager;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void Init()
        {
            if (_events == null)
            {
                _events = new Dictionary<EObserverActions, UnityEvent>();
            }
            if (_typedEvents == null)
            {   
                _typedEvents = new Dictionary<CustomEventTriggers, CustomEvent>();
            }
            if (eventDictionary == null)
            {
                eventDictionary = new Dictionary<string, Action>();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="listener"></param>
        public static void AddListener(EObserverActions eventName, UnityAction listener)
        {
            if (Instance._events.TryGetValue(eventName, out UnityEvent evt))
            {
                evt.AddListener(listener);
            }
            else
            {
                evt = new UnityEvent();
                evt.AddListener(listener);
                Instance._events.Add(eventName, evt);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="listener"></param>
        public static void RemoveListener(EObserverActions eventName, UnityAction listener)
        {
            if (_eventManager == null) return;
            if (Instance._events.TryGetValue(eventName, out UnityEvent evt))
                evt.RemoveListener(listener);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventName"></param>
        public static void TriggerEvent(EObserverActions eventName)
        {
            if (Instance._events.TryGetValue(eventName, out UnityEvent evt))
                evt.Invoke();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="listener"></param>
        public static void AddTypedListener(CustomEventTriggers eventType, UnityAction<CustomEventData> listener)
        {
            if (Instance._typedEvents.TryGetValue(eventType, out CustomEvent evt))
            {
                evt.AddListener(listener);
            }
            else
            {
                evt = new CustomEvent();
                evt.AddListener(listener);
                Instance._typedEvents.Add(eventType, evt);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="listener"></param>
        public static void RemoveTypedListener(CustomEventTriggers eventType, UnityAction<CustomEventData> listener)
        {
            if (_eventManager == null) return;
            if (Instance._typedEvents.TryGetValue(eventType, out CustomEvent evt))
                evt.RemoveListener(listener);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="data"></param>
        public static void TriggerTypedEvent(CustomEventTriggers eventType, CustomEventData data)
        {
            if (Instance._typedEvents.TryGetValue(eventType, out CustomEvent evt))
                evt.Invoke(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="listener"></param>
        public static void AddListener(string eventName, Action listener)
        {
            if (Instance.eventDictionary.TryGetValue(eventName, out Action thisEvent))
            {
                thisEvent += listener;

                Instance.eventDictionary[eventName] = thisEvent;
            }
            else
            {
                thisEvent += listener;
                Instance.eventDictionary.Add(eventName, thisEvent);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="listener"></param>
        public static void RemoveListener(string eventName, Action listener)
        {
            if (Instance.eventDictionary.TryGetValue(eventName, out Action thisEvent))
            {
                thisEvent -= listener;

                Instance.eventDictionary[eventName] = thisEvent;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventName"></param>
        public static void TriggerEvent(string eventName)
        {
            if (Instance.eventDictionary.TryGetValue(eventName, out Action thisEvent))
            {
                thisEvent?.Invoke();
            }
        }

        #endregion
    }
}