using UI;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MainMenuView : View
{
    [SerializeField] private Button playButton;
    [SerializeField] private GameObject puzzleGame;

    public override void Init()
    {
        SlideInButton();
        playButton.onClick.AddListener(StartGame);
    }

    private void SlideInButton()
    {
        var halfheight = Screen.height/2;
        var buttonPosition = playButton.transform.position;
        playButton.transform.position = new Vector3 (buttonPosition.x, -(halfheight + 40), buttonPosition.z);
        playButton.transform.DOMove(buttonPosition, 1f);
    }

    private void StartGame()
    {
        puzzleGame.SetActive(true);
        Hide();
    }
}
