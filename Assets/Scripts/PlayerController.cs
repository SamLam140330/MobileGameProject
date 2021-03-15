using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 _movement = Vector3.zero;

    private void Update()
    {
        _movement.x = -Input.acceleration.y;
        _movement.z = Input.acceleration.x;
        if (_movement.sqrMagnitude > 1)
        {
            _movement.Normalize();
        }
        _movement *= Time.deltaTime;
        transform.Translate(_movement * 12.0f);
    }
}
