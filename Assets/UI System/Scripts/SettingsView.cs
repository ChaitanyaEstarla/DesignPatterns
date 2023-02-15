using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SettingsView : View
    {
        [SerializeField] private Button backButton;
        
        public override void Init()
        {
            backButton.onClick.AddListener(()=> ViewManager.Show<MainMenuView>());
        }

        private void OnDestroy()
        {
            backButton.onClick.RemoveAllListeners();
        }
    }
}
