using UnityEngine;
using static DEFINE;

public class Target : PoolableMono
{
    [SerializeField] int maxHp = 3;
    private int currentHp = 0;

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

        HitEffect();

        if(currentHp <= 0)
            Die();
    }

    private void Die()
    {
        PoolManager.Instance.Push(this);
    }

    private void HitEffect()
    {
        TimeManager.Instance.SetTimeDelay(TimeDelayScale, HitEffectDuration);
        CameraManager.Instance.ShakeCam(HitEffectDuration, CamShakePower, CamShakeFreq);
    }
}
