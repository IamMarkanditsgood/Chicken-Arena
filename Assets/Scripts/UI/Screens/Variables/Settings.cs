using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : BasicScreen
{
    public Button a;
    public Button H;
    public Button p;
    public Button i;

    public Button sounds;
    public Button music;
    public Button vibrations;

    public Sprite onButton;
    public Sprite offButton;


    void Start()
    {
        a.onClick.AddListener(Arenas);
        H.onClick.AddListener(Home);
        p.onClick.AddListener(profile);
        i.onClick.AddListener(Info);


        sounds.onClick.AddListener(Sounds);
        music.onClick.AddListener(Music);
        vibrations.onClick.AddListener(Vibrations);
    }

    // Update is called once per frame
    void OnDestroy()
    {
        a.onClick.RemoveListener(Arenas);
        H.onClick.RemoveListener(Home);
        p.onClick.RemoveListener(profile);
        i.onClick.RemoveListener(Info);

        sounds.onClick.RemoveListener(Sounds);
        music.onClick.RemoveListener(Music);
        vibrations.onClick.RemoveListener(Vibrations);
    }


    public override void SetScreen()
    {
        SetSettings();
    }

    public override void ResetScreen()
    {
    }

    private void SetSettings()
    {
        SetMusci();
        SetSounds();
        SetVibration();
    }

    private void SetMusci()
    {
        int musicParam = 1;
        if (PlayerPrefs.HasKey("Musci"))
        {
            musicParam = PlayerPrefs.GetInt("Musci");
        }
        else
        {
            PlayerPrefs.SetInt("Musci", musicParam);
        }

        if(musicParam == 1)
        {
            music.gameObject.GetComponent<Image>().sprite = onButton;
        }
        else
        {
            music.gameObject.GetComponent<Image>().sprite = offButton;
        }
    }
    private void SetSounds()
    {
        int musicParam = 1;
        if (PlayerPrefs.HasKey("Sounds"))
        {
            musicParam = PlayerPrefs.GetInt("Sounds");
        }
        else
        {
            PlayerPrefs.SetInt("Sounds", musicParam);
        }

        if (musicParam == 1)
        {
            sounds.gameObject.GetComponent<Image>().sprite = onButton;
        }
        else
        {
            sounds.gameObject.GetComponent<Image>().sprite = offButton;
        }
    }
    private void SetVibration()
    {
        int musicParam = 1;
        if (PlayerPrefs.HasKey("Vibrations"))
        {
            musicParam = PlayerPrefs.GetInt("Vibrations");
        }
        else
        {
            PlayerPrefs.SetInt("Vibrations", musicParam);
        }

        if (musicParam == 1)
        {
            vibrations.gameObject.GetComponent<Image>().sprite = onButton;
        }
        else
        {
            vibrations.gameObject.GetComponent<Image>().sprite = offButton;
        }
    }

    private void Music()
    {
        int musicParam = PlayerPrefs.GetInt("Musci");
        if (musicParam == 1)
        {
            PlayerPrefs.SetInt("Musci", 0);
            music.gameObject.GetComponent<Image>().sprite = offButton;
        }
        else
        {
            PlayerPrefs.SetInt("Musci", 1);
            music.gameObject.GetComponent<Image>().sprite = onButton;
        }
    }

    private void Sounds()
    {
        int musicParam = PlayerPrefs.GetInt("Sounds");
        if (musicParam == 1)
        {
            PlayerPrefs.SetInt("Sounds", 0);
            sounds.gameObject.GetComponent<Image>().sprite = offButton;
        }
        else
        {
            PlayerPrefs.SetInt("Sounds", 1);
            sounds.gameObject.GetComponent<Image>().sprite = onButton;
        }
    }

    private void Vibrations()
    {
        int musicParam = PlayerPrefs.GetInt("Vibrations");
        if (musicParam == 1)
        {
            PlayerPrefs.SetInt("Vibrations", 0);
            vibrations.gameObject.GetComponent<Image>().sprite = offButton;
        }
        else
        {
            PlayerPrefs.SetInt("Vibrations", 1);
            vibrations.gameObject.GetComponent<Image>().sprite = onButton;
        }
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
    private void Info()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.Info);
    }
}
