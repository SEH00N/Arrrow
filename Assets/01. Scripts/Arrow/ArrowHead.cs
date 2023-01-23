using UnityEngine;

public class ArrowHead : MonoBehaviour
{
    [SerializeField] int damage = 1;
    public int Damage { get => damage; set => damage = value; }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Target"))
            if(other.TryGetComponent<Target>(out Target target))
                target.Hit(damage);
    }
}
