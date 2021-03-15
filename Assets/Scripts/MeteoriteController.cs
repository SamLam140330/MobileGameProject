using UnityEngine;

public class MeteoriteController : MonoBehaviour
{
    private ObjectSpawnManager _objectSpawnManager = null;

    private void Start()
    {
        _objectSpawnManager = FindObjectOfType<ObjectSpawnManager>();
    }

    private void Update()
    {
        Vector3 pos = transform.position;
        pos.x -= _objectSpawnManager._objectSpeed * Time.deltaTime;
        transform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collided with Meteorite");
            _objectSpawnManager.ObjectTouch();
            //Destroy(gameObject);
        }
    }
}
