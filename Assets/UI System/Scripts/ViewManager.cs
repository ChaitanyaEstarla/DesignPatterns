using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class ViewManager : MonoBehaviour
    {
        public static ViewManager Instance { get; private set; }

        [SerializeField] private View startingView;
        [SerializeField] private List<View> views;

        private View _currentView;

        private Stack<View> _history = new Stack<View>();

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
                return;
            }
            Instance = this;
        }

        private void Start()
        {
            foreach (var view in views)
            {
                view.Init();
                view.Hide();
            }
            
            if(startingView != null)
                Show(startingView, true);
        }

        public static T GetView<T>() where T : View
        {
            foreach (var t in Instance.views)
            {
                if (t is T view)
                    return view;
            }

            return null;
        }

        public static void Show<T>(bool remember = true) where T : View
        {
            for (var i = 0; i < Instance.views.Count; i++)
            {
                if (Instance.views[i] is not T) continue;
                if (Instance._currentView != null)
                {
                    if(remember)
                        Instance._history.Push(Instance._currentView);
                    Instance._currentView.Hide();
                }
                Instance.views[i].Show();
                Instance._currentView = Instance.views[i];
            }
        }

        public static void Show(View view, bool remember = true)
        {
            if (Instance._currentView != null)
            {
                if (remember)
                {
                    Instance._history.Push(Instance._currentView);
                }
                Instance._currentView.Hide();
            }
            view.Show();
            Instance._currentView = view;
        }

        public static void ShowLast()
        {
            if (Instance._history.Count != 0)
            {
                Show(Instance._history.Pop(), false);
            }
        }
    }
}
