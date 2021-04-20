using UnityEngine;

public class ObjectSpawnManager : MonoBehaviour
{
    [HideInInspector] public bool isGameOver = false;
    [HideInInspector] public float randomPosY = 0.0f;
    [HideInInspector] public float _objectSpeed = 3.0f;
    private GameObject player = null;
    private UIManager uiManager = null;
    private ObjectPooler objectPooler = null;
    private GameManager gameManager = null;
    private int totalEnemy = 1;
    public static float score = 0;

    private void Awake()
    {
        score = 0;
        gameManager = GameManager.Instance;
        objectPooler = FindObjectOfType<ObjectPooler>();
        uiManager = FindObjectOfType<UIManager>();
        player = GameObject.FindGameObjectWithTag("PlayerMain");
    }

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0.0f, 2.5f);
        InvokeRepeating(nameof(AddEnemy), 10.0f, 10.0f);
    }

    private void Update()
    {
        AddScore();
    }

    private void SpawnEnemy()
    {
        _objectSpeed += 0.2f;
        for (int i = 0; i < totalEnemy; i++)
        {
            GameObject enemy = objectPooler.GetPooledObject();
            if (enemy != null)
            {
                randomPosY = Random.Range(-5, 5);
                enemy.transform.position = new Vector3(11, randomPosY, 0);
                enemy.SetActive(true);
            }
        }
    }

    private void AddEnemy()
    {
        totalEnemy += 1;
    }

    private void AddScore()
    {
        if (isGameOver == false)
        {
            score += 1 * Time.deltaTime;
            uiManager.UpdateScoreTxt();
        }
    }

    public void GameOver()
    {
        CancelInvoke();
        isGameOver = true;
        uiManager.GameOver();
        player.SetActive(false);
        if (score > gameManager.highestScore)
        {
            gameManager.highestScore = (int)score;
            PlayerPrefs.SetInt("HighestScore", gameManager.highestScore);
        }
    }
}
