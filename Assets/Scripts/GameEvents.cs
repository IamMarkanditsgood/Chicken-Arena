using System;
using UnityEngine;

public static class GameEvents 
{
    public static event Action<int> OnEggsChange;
    public static event Action<int> OnScoreChange;
    public static event Action<int> OnBattleChange;
    public static event Action PlayerBaseDestroyed;
    public static event Action EnemyBaseDestroyed;
    public static event Action<GameObject> EnemyDead;
    public static event Action<GameObject> AlliDead;

    public static void ChangeEggs(int value) => OnEggsChange?.Invoke(value);
    public static void ChangeScore(int value) => OnScoreChange?.Invoke(value);
    public static void ChangeBattles(int value) => OnBattleChange?.Invoke(value);
    public static void DestroyPlayerBase() => PlayerBaseDestroyed?.Invoke();
    public static void DestroyEnemyBase() => EnemyBaseDestroyed?.Invoke();
    public static void DeadEnemy(GameObject enemy) => EnemyDead?.Invoke(enemy);
    public static void DeadAlly(GameObject enemy) => AlliDead?.Invoke(enemy);
}
