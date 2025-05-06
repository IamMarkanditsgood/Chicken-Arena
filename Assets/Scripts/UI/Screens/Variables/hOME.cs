using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hOME : BasicScreen
{
    public Button a;
    public Button i;
    public Button p;
    public Button S;

    public Button play;

    public GamePlayScreen _gameScreen;


    void Start()
    {
        a.onClick.AddListener(Arenas);
        i.onClick.AddListener(Info);
        p.onClick.AddListener(profile);
        S.onClick.AddListener(Settings);

        play.onClick.AddListener(PlayGame);
    }

    // Update is called once per frame
    void OnDestroy()
    {
        a.onClick.RemoveListener(Arenas);
        i.onClick.RemoveListener(Info);
        p.onClick.RemoveListener(profile);
        S.onClick.RemoveListener(Settings);

        play.onClick.RemoveListener(PlayGame);
    }


    public override void SetScreen()
    {
    }

    public override void ResetScreen()
    {
    }

    private void Arenas()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.Arenas);
    }

    private void Info()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.Info);
    }

    private void profile()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.Profile);
    }
    private void Settings()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.Settings);
    }

    private void PlayGame()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.Game);
        _gameScreen.StartGame();
    }
}
