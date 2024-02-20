using UI;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class SplashView : View
{
    [SerializeField] private TMP_Text splashText;

    private string splashPath = "1";

    public override void Init()
    {
        ShowBanner();
    }

    private void ShowBanner()
    {
        splashText.DOFade(2f, 1).From(0).OnComplete(FadeOut);
    }

    private void FadeOut()
    {
        var time = 1f;
        splashText.DOFade(0f, time);
        Invoke(nameof(JumpToNextScreen), time);
    }

    private void JumpToNextScreen()
    {
        ViewManager.Show<MainMenuView>(false);
    }
}
