using UnityEngine;

public class MeteoriteController : MonoBehaviour
{
    private ObjectSpawnManager objectSpawnManager = null;

    private void Awake()
    {
        objectSpawnManager = FindObjectOfType<ObjectSpawnManager>();
    }

    private void Update()
    {
        Vector3 pos = transform.position;
        pos.x -= objectSpawnManager._objectSpeed * Time.deltaTime;
        transform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objectSpawnManager.GameOver();
        }
        if (other.CompareTag("Barrier"))
        {
            gameObject.SetActive(false);
        }
    }
}
