using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayScreen : BasicScreen
{
    public AudioSource music;
    public AudioClip musicClip;

    public TMP_Text _gameScore;
    public TMP_Text _eggs;
    public TMP_Text _score;
    public TMP_Text _wineggs;
    public TMP_Text _winscore;

    private int eggs;
    private int score;

    public Transform _enemySpawnPos;
    public Transform _alliesSpawnPos;

    public GameObject[] _alliesUnitPrefabs;
    public GameObject[] _enemyUnitPrefabs;

    public Button[] _unitButtons;
    public int[] _prices;

    private int currentGameScore;
    private int gameTimer = 0;

    private Coroutine scoreTimer;
    private Coroutine gamePlay;

    private List<GameObject> _enemies = new();
    public EnemyBase[] _bases;
    private void Start()
    {
        for(int i = 0; i < _unitButtons.Length; i++)
        {
            int index = i;
            _unitButtons[index].onClick.AddListener(() => SpawnUnit(index));
        }
        GameEvents.EnemyDead += EnemyDead;
        GameEvents.EnemyBaseDestroyed += Win;
        GameEvents.PlayerBaseDestroyed += Lose;
        GameEvents.AlliDead += DeadElly;

    }

    private void OnDestroy()
    {
        for (int i = 0; i < _unitButtons.Length; i++)
        {
            int index = i;
            _unitButtons[index].onClick.RemoveListener(() => SpawnUnit(index));
        }
        GameEvents.EnemyDead -= EnemyDead;
        GameEvents.EnemyBaseDestroyed -= Win;
        GameEvents.PlayerBaseDestroyed -= Lose;
        GameEvents.AlliDead -= DeadElly;
    }
    public override void ResetScreen()
    {
        FinishGame();
        if (PlayerPrefs.GetInt("Musci") == 1)
        {
            music.Stop();
        }
    }

    public override void SetScreen()
    {
    }

    private void FinishGame()
    {
        Time.timeScale = 0.0f;
        if(gamePlay != null)
            StopCoroutine(gamePlay);
        if (scoreTimer != null)
            StopCoroutine(scoreTimer);
        currentGameScore = 0;
        gameTimer = 0;
        eggs = 0;
        score = 0;

        _gameScore.text = currentGameScore.ToString();
        _eggs.text = eggs.ToString();
        _score.text = score.ToString();
    }
    public void StartGame()
    {
        if(PlayerPrefs.GetInt("Musci") == 1)
        {
            music.clip = musicClip;
            music.Play();
        }

        foreach(var enemy in _enemies)
        {
            Destroy(enemy);
        }
        _enemies.Clear();
        foreach (var b in _bases)
        {
            b.Restart();
        }
        Time.timeScale = 1f;
        currentGameScore = 24;
        gamePlay = StartCoroutine(GamePlay());
        scoreTimer = StartCoroutine(ScoreTimer());
    }

    private IEnumerator GamePlay()
    {
        while (true)
        {
            int random = Random.Range(0, 100);
            int unitIndex = 0;
            if (random >= 0 && random <= 50)
            {
                unitIndex = 0;
            }
            else if(random > 50 && random <= 90)
            {
                unitIndex = 1;
            }
            else if(random > 90)
            {
                unitIndex = 2;
            }
            GameObject newEnemy = Instantiate(_enemyUnitPrefabs[unitIndex]);
            _enemies.Add(newEnemy);
            newEnemy.transform.SetPositionAndRotation(_enemySpawnPos.position, _enemySpawnPos.localRotation);
            int randomTime = Random.Range(5, 15);
            yield return new WaitForSeconds(randomTime);
        }
    }
    private IEnumerator ScoreTimer()
    {
        while (true)
        {
            currentGameScore++;
            gameTimer++;
            _gameScore.text = currentGameScore.ToString();
            UpdateButtons();
            yield return new WaitForSeconds(1);
        }
    }

    private void UpdateButtons()
    {
        for (int i = 0; i < _unitButtons.Length; i++)
        {
            _unitButtons[i].interactable = false;
        }

        for (int i = 0;i < _unitButtons.Length; i++)
        {
            if(currentGameScore >= _prices[i])
            {
                _unitButtons[i].interactable = true;
            }
        }
    }

    private void SpawnUnit(int index)
    {
        currentGameScore -= _prices[index];
        UpdateButtons();
        _gameScore.text = currentGameScore.ToString();
        GameObject newUnit = Instantiate(_alliesUnitPrefabs[index]);
        _enemies.Add(newUnit);
        newUnit.transform.SetPositionAndRotation(_alliesSpawnPos.position, _alliesSpawnPos.localRotation);
    }

    private void Win()
    {
        GameEvents.ChangeBattles(1);
        PlayerPrefs.SetInt("Achieve0", 1);
        GameEvents.ChangeEggs(eggs);
        GameEvents.ChangeScore(score);
        _wineggs.text = eggs.ToString();
        _winscore.text = score.ToString();
        UIManager.Instance.ShowPopup(PopupTypes.Win);
        FinishGame();
    }
    private void Lose()
    {
        GameEvents.ChangeBattles(1);
        UIManager.Instance.ShowPopup(PopupTypes.Lose);
        FinishGame();
    }

    private void DeadElly(GameObject ally)
    {
        _enemies.Remove(ally);
    }
    private void EnemyDead(GameObject enemy)
    {
        eggs += 10;
        score += 10;
        _eggs.text = eggs.ToString();
        _score.text = score.ToString();
        _enemies.Remove(enemy);
    }
}