using UnityEngine;

public class ObjectSpawnManager : MonoBehaviour
{
    [HideInInspector] public bool isGameOver = false;
    [HideInInspector] public float randomPosY = 0.0f;
    [HideInInspector] public float objectSpeed = 3.0f;
    private GameObject player = null;
    private UIManager uiManager = null;
    private ObjectPooler objectPool = null;
    private GameManager gameManager = null;
    private PlayerController playerController = null;
    private BackgroundController backgroundController = null;
    private int totalEnemy = 1;
    private int enemyType = 0;
    private bool changeHardMode = false;
    private bool isHardMode = false;
    public static float Score = 0f;

    private void Awake()
    {
        Score = 0;
        changeHardMode = false;
        isHardMode = false;
        gameManager = GameManager.Instance;
        objectPool = FindObjectOfType<ObjectPooler>();
        uiManager = FindObjectOfType<UIManager>();
        playerController = FindObjectOfType<PlayerController>();
        backgroundController = FindObjectOfType<BackgroundController>();
        player = GameObject.FindGameObjectWithTag("PlayerMain");
    }

    private void Start()
    {
        InvokeRepeating(nameof(SpawnItem), 6f, 6f);
        InvokeRepeating(nameof(SpawnEnemy), 1f, 4f);
        InvokeRepeating(nameof(AddEnemy), 10.0f, 12.0f);
    }

    private void Update()
    {
        if (isGameOver == false)
        {
            AddScore();
            if (changeHardMode == true && isHardMode == false)
            {
                isHardMode = true;
                ChangeToHardMode();
            }
        }
    }

    private void AddScore()
    {
        Score += 1 * Time.deltaTime;
        uiManager.UpdateScoreTxt();
        if (Score >= 120 && changeHardMode == false)
        {
            changeHardMode = true;
        }
    }

    private void ChangeToHardMode()
    {
        CancelInvoke(nameof(SpawnEnemy));
        InvokeRepeating(nameof(SpawnEnemy), 0f, 2f);
        backgroundController.bgMoveSpeed = 10f;
    }

    private void SpawnItem()
    {
        if (playerController.BulletSpawnTime > 0.5)
        {
            GameObject enemy = objectPool.GetPooledItemObject();
            if (enemy != null)
            {
                randomPosY = Random.Range(-5, 5);
                enemy.transform.position = new Vector3(11, randomPosY, 0);
                enemy.SetActive(true);
            }
        }
        else
        {
            CancelInvoke(nameof(SpawnItem));
        }
    }

    private void SpawnEnemy()
    {
        if (isHardMode == false)
        {
            objectSpeed += 0.2f;
        }
        else
        {
            objectSpeed += 0.4f;
        }
        for (int i = 0; i < totalEnemy; i++)
        {
            RandomSpawnPosition();
        }
    }

    private void RandomSpawnPosition()
    {
        enemyType = Random.Range(0, 4);
        if (isHardMode == false)
        {
            if (enemyType == 0 || enemyType == 1 || enemyType == 2)
            {
                GameObject enemyA = objectPool.GetPooledEnemyAObject();
                if (enemyA != null)
                {
                    randomPosY = Random.Range(-5, 5);
                    enemyA.transform.position = new Vector3(11, randomPosY, 0);
                    enemyA.SetActive(true);
                }
            }
            else if (enemyType == 3 && Score > 30)
            {
                GameObject enemyB = objectPool.GetPooledEnemyBObject();
                if (enemyB != null)
                {
                    randomPosY = Random.Range(-5, 5);
                    enemyB.transform.position = new Vector3(11, randomPosY, 0);
                    enemyB.SetActive(true);
                }
            }
        }
        else
        {
            if (enemyType == 0 || enemyType == 1)
            {
                GameObject enemyA = objectPool.GetPooledEnemyAObject();
                if (enemyA != null)
                {
                    randomPosY = Random.Range(-5, 5);
                    enemyA.transform.position = new Vector3(11, randomPosY, 0);
                    enemyA.SetActive(true);
                }
            }
            else
            {
                GameObject enemyB = objectPool.GetPooledEnemyBObject();
                if (enemyB != null)
                {
                    randomPosY = Random.Range(-5, 5);
                    enemyB.transform.position = new Vector3(11, randomPosY, 0);
                    enemyB.SetActive(true);
                }
            }
        }
    }

    private void AddEnemy()
    {
        if (totalEnemy < 10)
        {
            totalEnemy += 1;
        }
        else
        {
            CancelInvoke(nameof(AddEnemy));
        }
    }

    public void GameOver()
    {
        CancelInvoke();
        playerController.StopShot();
        isGameOver = true;
        player.SetActive(false);
        if (Score > gameManager.highestScore)
        {
            gameManager.highestScore = (int)Score;
            PlayerPrefs.SetInt("HighestScore", gameManager.highestScore);
        }
        uiManager.GameOver();
    }
}
