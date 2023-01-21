using UnityEngine;

public class TArrow : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Target"))
            Destroy(other.gameObject);
    }
}
