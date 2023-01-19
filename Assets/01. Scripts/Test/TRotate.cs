using UnityEngine;

public class TRotate : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            Debug.Log(transform.eulerAngles.z);
    }
}
