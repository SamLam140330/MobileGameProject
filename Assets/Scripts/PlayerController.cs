using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private ObjectSpawnManager objectSpawnManager = null;
    private Vector3 _movement = Vector3.zero;

    private void Awake()
    {
        objectSpawnManager = FindObjectOfType<ObjectSpawnManager>();
    }

    private void Start()
    {
        transform.position = new Vector3(-8f, 0f, 0f);
    }

    private void Update()
    {
        if (objectSpawnManager.isGameOver == false)
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
}
