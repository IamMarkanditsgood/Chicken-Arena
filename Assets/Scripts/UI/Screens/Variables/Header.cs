using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Header : MonoBehaviour
{
    private TextManager textManager = new TextManager();
    public TMP_Text eggsText;
    public TMP_Text scoreText;
    public TMP_Text battlesText;

    public void Start()
    {
        GameEvents.OnEggsChange += UpdateEggs;
        GameEvents.OnScoreChange += UpdateScore;
        GameEvents.OnBattleChange += UpdateButtles;

        UpdateEggs();
        UpdateScore();
        UpdateButtles();
    }

    private void OnDestroy()
    {
        GameEvents.OnEggsChange -= UpdateEggs;
        GameEvents.OnScoreChange -= UpdateScore;
        GameEvents.OnBattleChange -= UpdateButtles;
    }

    private void UpdateEggs(int value = 0)
    {
        
        int eggs = PlayerPrefs.GetInt("Eggs");
        eggs += value;
        if (eggs == 1000)
        {
            PlayerPrefs.SetInt("Achieve1", 1);
        }
        PlayerPrefs.SetInt("Eggs" , eggs);
        textManager.SetText(eggs, eggsText, true);
    }

    private void UpdateScore(int value = 0)
    {
        int eggs = PlayerPrefs.GetInt("Score");
        eggs += value;
        if (eggs == 1000)
        {
            PlayerPrefs.SetInt("Achieve3", 1);
        }
        PlayerPrefs.SetInt("Score", eggs);
        textManager.SetText(eggs, scoreText, true);
    }
    private void UpdateButtles(int value = 0)
    {
        int eggs = PlayerPrefs.GetInt("Battles");
        eggs += value;

        if(eggs == 25)
        {
            PlayerPrefs.SetInt("Achieve4", 1);

        }
        if (eggs == 50)
        {
            PlayerPrefs.SetInt("Achieve2", 1);

        }
        if (eggs == 100)
        {
            PlayerPrefs.SetInt("Achieve5", 1);

        }
        PlayerPrefs.SetInt("Battles", eggs);
        if(eggs > 100)
        {
            eggs = 100;
        }
        battlesText.text = "Battles " + eggs + "/100";
    }
}
