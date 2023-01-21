using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField, Tooltip("The distance from the center the stick able to move")] float maxDistance = 10f;
    [SerializeField, Tooltip("the speed at which the stick returns when the drag is finished")] float returningSpeed = 50f;

    [Header("Events")]
    [SerializeField] UnityEvent<Vector2> OnValueChagned;
    [SerializeField] UnityEvent OnDragStart;
    [SerializeField] UnityEvent OnDragEnd;

    private Vector3 center = Vector3.zero;
    public Vector3 Center => center;

    private bool onDragged = false;
    public bool OnDragged => onDragged;

    private void Awake()
    {
        center = transform.position;
    }

    private void Update()
    {
        if(onDragged == false)
            transform.localPosition = Vector3.Lerp(transform.localPosition, Vector3.zero, Time.deltaTime * returningSpeed);
        else
            OnValueChagned?.Invoke(GetJoyStickValue());
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        onDragged = true;
        OnDragStart?.Invoke();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;

        if(GetDistance(center, transform.position) > maxDistance)
        {
            Vector3 normalFactor = GetJoyStickValue();
            transform.position = center + normalFactor * maxDistance;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        onDragged = false;
        OnDragEnd?.Invoke();;
    }

    public Vector2 GetJoyStickValue() => (transform.position - center).normalized;

    private float GetDistance(Vector2 one, Vector2 two)
    {
        Vector2 err = two - one;
        float aSqr = Mathf.Pow(err.x, 2);
        float bSqr = Mathf.Pow(err.y, 2);

        float cSqr = aSqr + bSqr;

        return Mathf.Sqrt(cSqr);
    }
}
