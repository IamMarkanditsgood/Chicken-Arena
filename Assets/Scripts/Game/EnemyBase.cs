using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyBase : MonoBehaviour, IDamageable
{
    public TMP_Text _healthText;
    public int health = 100;
    public UnitType unitType;

    public bool IsAlive()
    {
        return health > 0;
    }

    public void Restart()
    {
        health = 100;
        _healthText.text = health.ToString();
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if(health < 0)
            health = 0;

        _healthText.text = health.ToString();
        if (health <= 0)
        {
            if (unitType == UnitType.Enemy)
            {
                GameEvents.DestroyEnemyBase();
            }
            else if(unitType == UnitType.Ally)
            {
                GameEvents.DestroyPlayerBase();
            }
        }
    }
}
