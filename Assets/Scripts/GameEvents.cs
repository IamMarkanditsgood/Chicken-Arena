using System;

public static class GameEvents 
{
    public static event Action<int> OnEggsChange;
    public static event Action<int> OnScoreChange;
    public static event Action<int> OnBattleChange;

    public static void ChangeEggs(int value) => OnEggsChange(value);
    public static void ChangeScore(int value) => OnScoreChange(value);
    public static void ChangeBattles(int value) => OnBattleChange(value);
}
