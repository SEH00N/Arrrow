
using UnityEngine;

public class TMove : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float rotateSpeed = 10f;

    private void Update()
    {
        Rotator();
        Movement();
    }

    private void Movement()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }

    private void Rotator()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 input = new Vector2(x, y);

        if(input.SqrMagnitude() <= 0f)
            return;

        Vector2 directionVector = input.normalized;
        float angle = Mathf.Atan2(directionVector.y, directionVector.x) * Mathf.Rad2Deg - 90f;
        Quaternion targetQuaternion = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetQuaternion, Time.deltaTime * rotateSpeed);
    }
}
