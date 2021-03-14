using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 _movement = Vector3.zero;

    void Update()
    {
        // Remap device acceleration axis to game coordinates:
        // 1) XY plane of the device is mapped onto XZ plane
        // 2) Rotated 90 degrees around Y axis
        _movement.x = -Input.acceleration.y;
        _movement.z = Input.acceleration.x;

        // Clamp acceleration vector to unit sphere
        if (_movement.sqrMagnitude > 1)
        {
            _movement.Normalize();
        }

        // Make it move 10 meters per second instead of 10 meters per frame...
        _movement *= Time.deltaTime;

        // Move object
        transform.Translate(_movement * 12.0f);
    }
}
