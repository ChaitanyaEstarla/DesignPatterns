using UnityEngine;
using Button = UnityEngine.UI.Button;

namespace UI
{
    public class MainMenuView : View
    {
        [SerializeField] private Button startButton;
        
        public override void Init()
        {
            startButton.onClick.AddListener(() => ViewManager.Show<SettingsView>());
        }
        
        private void OnDestroy()
        {
            startButton.onClick.RemoveAllListeners();
        }
    }
}