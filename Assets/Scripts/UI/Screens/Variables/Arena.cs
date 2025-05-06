using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arena : BasicScreen
{
    public Button i;
    public Button H;
    public Button p;
    public Button S;

    public Button go;
    public Button unlock;


    void Start()
    {
        i.onClick.AddListener(Info);
        H.onClick.AddListener(Home);
        p.onClick.AddListener(profile);
        S.onClick.AddListener(Settings);
        go.onClick.AddListener(Home);
    }

    // Update is called once per frame
    void OnDestroy()
    {
        i.onClick.RemoveListener(Info);
        H.onClick.RemoveListener(Home);
        p.onClick.RemoveListener(profile);
        S.onClick.RemoveListener(Settings);
        go.onClick.RemoveListener(Home);
    }


    public override void SetScreen()
    {
        if(PlayerPrefs.GetInt("Battles") >= 100)
        {
            unlock.interactable = false;
        }
    }

    public override void ResetScreen()
    {
    }

    private void Info()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.Info);
    }

    private void Home()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.Home);
    }

    private void profile()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.Profile);
    }
    private void Settings()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.Settings);
    }
}
