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
        PlayerPrefs.SetInt("Eggs" , eggs);
        textManager.SetText(eggs, eggsText, true);
    }

    private void UpdateScore(int value = 0)
    {
        int eggs = PlayerPrefs.GetInt("Score");
        eggs += value;
        PlayerPrefs.SetInt("Score", eggs);
        textManager.SetText(eggs, scoreText, true);
    }
    private void UpdateButtles(int value = 0)
    {
        int eggs = PlayerPrefs.GetInt("Battles");
        eggs += value;
        PlayerPrefs.SetInt("Eggs", eggs);
        if(eggs > 100)
        {
            eggs = 100;
        }
        battlesText.text = "Battles " + eggs + "/100";
    }
}
