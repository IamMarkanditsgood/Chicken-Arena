using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public enum UnitType
{
    Ally,   // Союзник
    Enemy   // Ворог
}

public class CharacterController : MonoBehaviour, IDamageable
{
    [Header("Unit Properties")]
    public int health = 100;
    public int damage = 10;
    public float moveSpeed = 3f;
    public float attackInterval = 1f;
    public UnitType unitType;
    public Vector2 moveDirection = Vector2.right;

    private bool isAttacking = false;
    private bool isAlive = true;
    private Transform target;   // Ціль, на яку атакує юніт
    private RaycastHit2D[] raycastHits;

    private Coroutine moveCoroutime;
    private Coroutine attackCoroutime;


    private void Start()
    {
        // Приклад, як встановити напрямок руху
        moveCoroutime = StartCoroutine(MoveUnit());
    }

    private void Update()
    {
        if (isAlive)
        {
            // Перевірка на наявність ворога перед юнітом
            CheckForEnemiesInFront();
        }
    }

    private void CheckForEnemiesInFront()
    {
        if (isAttacking) return;

        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, moveDirection, 1.5f);

        foreach (var hit in hits)
        {
            var unit = hit.collider.GetComponent<CharacterController>();
            if (unit != null && unit.IsAlive() && unit.unitType != unitType)
            {
                StopMovement();
                target = unit.transform;
                attackCoroutime = StartCoroutine(AttackTarget());
                break;
            }

            var baseTarget = hit.collider.GetComponent<EnemyBase>();
            if (baseTarget != null && baseTarget.unitType != unitType)
            {
                StopMovement();
                target = baseTarget.transform;
                attackCoroutime = StartCoroutine(AttackTarget());
                break;
            }
        }
    }

    private IEnumerator AttackTarget()
    {
        isAttacking = true;

        IDamageable damageable = target.GetComponent<IDamageable>();

        while (target != null && damageable != null && damageable.IsAlive())
        {
            damageable.TakeDamage(damage);
            yield return new WaitForSeconds(1f);
        }

        isAttacking = false;
        target = null;
        StartMovement();
        StopCoroutine(attackCoroutime);
        attackCoroutime = null;
    }

    private IEnumerator MoveUnit()
    {
        while (isAlive)
        {
            if (target == null) // Рухається лише якщо немає ворога
            {
                transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
            }
            yield return null;
        }
    }

    private void StopMovement()
    {
        Debug.Log("Stop");
        // Зупинити рух
        StopCoroutine(moveCoroutime);
        moveCoroutime = null;   
    }

    private void StartMovement()
    {
        Debug.Log("Move");
        // Запустити рух
        moveCoroutime = StartCoroutine(MoveUnit());
    }

    public void TakeDamage(int damage)
    {
       
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public bool IsAlive()
    {
        return health > 0;
    }

    private void Die()
    {
        if (unitType == UnitType.Enemy)
        {
            GameEvents.DeadEnemy(gameObject);
        }
        else
        {
            GameEvents.DeadAlly(gameObject);
        }
        isAlive = false;
        Destroy(gameObject);
    }
}
