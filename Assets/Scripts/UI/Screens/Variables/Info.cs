using UnityEngine.UI;

public class Info : BasicScreen
{
    public Button a;
    public Button H;
    public Button p;
    public Button S;


    void Start()
    {
        a.onClick.AddListener(Arenas);
        H.onClick.AddListener(Home);
        p.onClick.AddListener(profile);
        S.onClick.AddListener(Settings);
    }

    // Update is called once per frame
    void OnDestroy()
    {
        a.onClick.RemoveListener(Arenas);
        H.onClick.RemoveListener(Home);
        p.onClick.RemoveListener(profile);
        S.onClick.RemoveListener(Settings);
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
