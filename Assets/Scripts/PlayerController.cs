using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void Update()
    {
        transform.Translate(Input.acceleration.x, 0, -Input.acceleration.z);
    }
}
