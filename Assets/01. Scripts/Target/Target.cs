using System;
using UnityEngine;

public class Target : PoolableMono
{
    [SerializeField] int maxHp = 3;
    private int currentHp = 0;
    
    [Header("Hit Effect")]
    [SerializeField] float timeDelayScale = 0.2f;
    [SerializeField] float timeDelayDuration = 0.4f;

    private void Awake()
    {
        Reset();
    }

    public override void Reset()
    {
        currentHp = maxHp;    
    }

    public void Hit(int damage)
    {
        currentHp -= damage;
        TimeManager.Instance.SetTimeDelay(timeDelayScale, timeDelayDuration);

        if(currentHp <= 0)
            Die();
    }

    private void Die()
    {
        PoolManager.Instance.Push(this);
    }
}
