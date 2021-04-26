using UnityEngine;

public class EnemyBController : MonoBehaviour
{
    private ObjectSpawnManager objectSpawnManager = null;
    private int enemyBhp = 3;

    private void Awake()
    {
        objectSpawnManager = FindObjectOfType<ObjectSpawnManager>();
    }

    private void OnEnable()
    {
        enemyBhp = 3;
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
            enemyBhp -= 1;
            if (enemyBhp > 0)
            {
                if (GameManager.Instance.isAudioOn == true)
                {
                    GameManager.Instance.PlaySound(2);
                }
            }
            else
            {
                if (GameManager.Instance.isAudioOn == true)
                {
                    GameManager.Instance.PlaySound(1);
                }
                gameObject.SetActive(false);
            }
        }
    }
}
