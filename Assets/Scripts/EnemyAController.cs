using UnityEngine;

public class EnemyAController : MonoBehaviour
{
    private ObjectSpawnManager objectSpawnManager = null;
    private int enemyAhp = 1;

    private void Awake()
    {
        objectSpawnManager = FindObjectOfType<ObjectSpawnManager>();
    }

    private void OnEnable()
    {
        enemyAhp = 1;
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
        if (other.CompareTag("Barrier"))
        {
            gameObject.SetActive(false);
        }
        if (other.CompareTag("Player"))
        {
            objectSpawnManager.GameOver();
        }
        if (other.CompareTag("Bullet"))
        {
            other.gameObject.SetActive(false);
            enemyAhp -= 1;
            if (enemyAhp <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
