using UnityEngine;

public class ObjectSpawnManager : MonoBehaviour
{
    [HideInInspector] public bool isGameOver = false;
    [HideInInspector] public float randomPosY = 0.0f;
    [HideInInspector] public float objectSpeed = 3.0f;
    private GameObject player = null;
    private UIManager uiManager = null;
    private ObjectPooler objectPooler = null;
    private GameManager gameManager = null;
    private PlayerController playerController = null;
    private BackgroundController backgroundController = null;
    private int totalEnemy = 1;
    private int enemyType = 0;
    private bool changeHardmode = false;
    private bool isHardmode = false;
    public static float score = 0;

    private void Awake()
    {
        score = 0;
        changeHardmode = false;
        isHardmode = false;
        gameManager = GameManager.Instance;
        objectPooler = FindObjectOfType<ObjectPooler>();
        uiManager = FindObjectOfType<UIManager>();
        playerController = FindObjectOfType<PlayerController>();
        backgroundController = FindObjectOfType<BackgroundController>();
        player = GameObject.FindGameObjectWithTag("PlayerMain");
    }

    private void Start()
    {
        InvokeRepeating(nameof(SpawnItem), 5f, 6f);
        InvokeRepeating(nameof(SpawnEnemy), 0f, 4f);
        InvokeRepeating(nameof(AddEnemy), 12.0f, 12.0f);
    }

    private void Update()
    {
        AddScore();
        ChangeToHardmode();
    }

    private void SpawnItem()
    {
        if (playerController.bulletSpawnTime > 0.5)
        {
            GameObject enemy = objectPooler.GetPooledItemObject();
            if (enemy != null)
            {
                randomPosY = Random.Range(-5, 5);
                enemy.transform.position = new Vector3(11, randomPosY, 0);
                enemy.SetActive(true);
            }
        }
        else
        {
            CancelInvoke("SpawnItem");
        }
    }

    private void SpawnEnemy()
    {
        if (isHardmode == false)
        {
            objectSpeed += 0.2f;
        }
        else
        {
            objectSpeed += 0.5f;
        }
        for (int i = 0; i < totalEnemy; i++)
        {
            RandomSpawnPosition();
        }
    }

    private void RandomSpawnPosition()
    {
        if (changeHardmode == false)
        {
            enemyType = Random.Range(0, 3);
        }
        if (enemyType == 0 || enemyType == 1)
        {
            GameObject enemyA = objectPooler.GetPooledEnemyAObject();
            if (enemyA != null)
            {
                randomPosY = Random.Range(-5, 5);
                enemyA.transform.position = new Vector3(11, randomPosY, 0);
                enemyA.SetActive(true);
            }
        }
        else if (enemyType == 2 && score > 50)
        {
            GameObject enemyB = objectPooler.GetPooledEnemyBObject();
            if (enemyB != null)
            {
                randomPosY = Random.Range(-5, 5);
                enemyB.transform.position = new Vector3(11, randomPosY, 0);
                enemyB.SetActive(true);
            }
        }
    }

    private void AddEnemy()
    {
        if (totalEnemy < 8)
        {
            totalEnemy += 1;
        }
        else
        {
            CancelInvoke("AddEnemy");
        }
    }

    private void AddScore()
    {
        if (isGameOver == false)
        {
            score += 1 * Time.deltaTime;
            uiManager.UpdateScoreTxt();
            if (score >= 150 && changeHardmode == false)
            {
                changeHardmode = true;
            }
        }
    }

    private void ChangeToHardmode()
    {
        if (changeHardmode == true && isHardmode == false)
        {
            isHardmode = true;
            CancelInvoke("SpawnEnemy");
            InvokeRepeating(nameof(SpawnEnemy), 0f, 1f);
            enemyType = 2;
            backgroundController.bgMoveSpeed = 10f;
        }
    }

    public void GameOver()
    {
        CancelInvoke();
        playerController.StopShot();
        isGameOver = true;
        player.SetActive(false);
        if (score > gameManager.highestScore)
        {
            gameManager.highestScore = (int)score;
            PlayerPrefs.SetInt("HighestScore", gameManager.highestScore);
        }
        uiManager.GameOver();
    }
}
