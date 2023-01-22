using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float rotateSpeed = 50f;

    private Rigidbody2D rb2d = null;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb2d.velocity = transform.up * moveSpeed;
    }

    public void DoRotate(Vector2 input)
    {
        if(input.SqrMagnitude() <= 0)
            return;

        Vector2 directionVector = input.normalized;
        float angle = Mathf.Atan2(directionVector.y, directionVector.x) * Mathf.Rad2Deg - 90f;

        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);
    }
}
