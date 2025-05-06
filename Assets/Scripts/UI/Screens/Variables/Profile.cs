using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Profile : BasicScreen
{
    public Button a;
    public Button H;
    public Button i;
    public Button S;
    public Button avatar;
    public AvatarManager avatarManager;
    public TMP_InputField name;

    public Image[] achievementsImage;
    public Sprite[] openedAchievements;


    [SerializeField] private TMP_Text displayText; // посилання на UI Text

    private const string FirstLaunchKey = "FirstLaunchDate";

    void Start()
    {
        a.onClick.AddListener(Arenas);
        H.onClick.AddListener(Home);
        i.onClick.AddListener(Info);
        S.onClick.AddListener(Settings);
        avatar.onClick.AddListener(Avatar);
    }

    // Update is called once per frame
    void OnDestroy()
    {
        a.onClick.RemoveListener(Arenas);
        H.onClick.RemoveListener(Home);
        i.onClick.RemoveListener(Info);
        S.onClick.RemoveListener(Settings);
        avatar.onClick.RemoveListener(Avatar);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("Name", name.text);
    }

    public override void SetScreen()
    {

        avatarManager.SetSavedPicture();
        name.text = PlayerPrefs.GetString("Name", "USER_NAME");
        SetTimer();
        SetAchievements();
    }

    public override void ResetScreen()
    { 
    }

    private void SetTimer()
    {
        string savedDate = PlayerPrefs.GetString(FirstLaunchKey, "");

        if (string.IsNullOrEmpty(savedDate))
        {
            savedDate = DateTime.Now.ToString("dd.MM.yyyy");
            PlayerPrefs.SetString(FirstLaunchKey, savedDate);
            PlayerPrefs.Save();
        }

        displayText.text = $"In the game\nsince {savedDate}";
    }

    private void SetAchievements()
    {
        for(int i = 0; i < achievementsImage.Length; i++)
        {
            string key = "Achieve" + i;
            if (PlayerPrefs.GetInt(key) == 1)
            {
                achievementsImage[i].sprite = openedAchievements[i];
            }
        }
    }
    private void Arenas()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.Arenas);
        PlayerPrefs.SetString("Name", name.text);
    }

    private void Home()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.Home);
        PlayerPrefs.SetString("Name", name.text);
    }

    private void Info()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.Info);
        PlayerPrefs.SetString("Name", name.text);
    }
    private void Settings()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.Settings);
        PlayerPrefs.SetString("Name", name.text);
    }
    private void Avatar()
    {
        avatarManager.PickFromGallery();
    }
}
