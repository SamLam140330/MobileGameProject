using UnityEngine;

public class EnemyBController : MonoBehaviour
{
    private ObjectSpawnManager objectSpawnManager = null;

    private void Awake()
    {
        objectSpawnManager = FindObjectOfType<ObjectSpawnManager>();
    }

    private void Update()
    {
        if (objectSpawnManager.isGameOver == false)
        {
            Vector3 pos = transform.position;
            pos.x -= objectSpawnManager.objectSpeed * Time.deltaTime;
            transform.position = pos;
        }
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
