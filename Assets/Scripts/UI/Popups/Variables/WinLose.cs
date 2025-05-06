using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinLose : BasicPopup
{
    public GameScreen _gameScreen;

    public Button playAgain;

    public override void Subscribe()
    {
        base.Subscribe();

        playAgain.onClick.AddListener(PlayAgain);
    }

    public override void Unsubscribe()
    {
        base.Unsubscribe();

        playAgain.onClick.RemoveListener(PlayAgain);
    }

    public override void ResetPopup()
    {
    }

    public override void SetPopup()
    {
    }

    public override void Hide()
    {
        base.Hide();
        UIManager.Instance.ShowScreen(ScreenTypes.Home);
    }

    private void PlayAgain()
    {
        base.Hide();
        UIManager.Instance.ShowScreen(ScreenTypes.Game);
        _gameScreen.StartGame();    
    }
}
