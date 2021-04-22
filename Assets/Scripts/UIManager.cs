using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel = null;
    [SerializeField] private GameObject gameOverPanel = null;
    [SerializeField] private Image audioImage = null;
    [SerializeField] private TextMeshProUGUI scoreTxt = null;
    [SerializeField] private TextMeshProUGUI gameoverScoreTxt = null;
    [SerializeField] private TextMeshProUGUI gameoverHigherScoreTxt = null;
    [SerializeField] private AudioSource[] audioSources = null;
    private GameManager gameManager = null;

    private void Awake()
    {
        gameManager = GameManager.Instance;
        Time.timeScale = 1f;
        UpdateScoreTxt();
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    private void Start()
    {
        CheckAudioSetting();
    }

    private void CheckAudioSetting()
    {
        if (gameManager.isAudioOn == true)
        {
            audioImage.sprite = gameManager.images[1];
            for (int i = 0; i < audioSources.Length; i++)
            {
                audioSources[i].Play();
            }
        }
        else
        {
            audioImage.sprite = gameManager.images[0];
            for (int i = 0; i < audioSources.Length; i++)
            {
                audioSources[i].Stop();
            }
        }
    }

    public void UpdateScoreTxt()
    {
        scoreTxt.SetText("Score: " + ((int)ObjectSpawnManager.score).ToString());
    }

    public void GameOver()
    {
        for (int i = 0; i < audioSources.Length; i++)
        {
            audioSources[i].Stop();
        }
        pausePanel.SetActive(false);
        gameoverScoreTxt.SetText("Your Score: " + ((int)ObjectSpawnManager.score).ToString());
        gameoverHigherScoreTxt.SetText("Higher Score: " + gameManager.highestScore.ToString());
        gameOverPanel.SetActive(true);
    }

    public void OnPauseButtonClicked()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void OnResumeButoonClicked()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void OnRetryButtonClicked()
    {
        SceneManager.LoadScene(1);
    }

    public void OnHomeButtonClicked()
    {
        SceneManager.LoadScene(0);
    }

    public void OnAudioButtonClicked()
    {
        if (gameManager.isAudioOn == true)
        {
            audioImage.sprite = gameManager.images[0];
            gameManager.isAudioOn = false;
            CheckAudioSetting();
        }
        else
        {
            audioImage.sprite = gameManager.images[1];
            gameManager.isAudioOn = true;
            CheckAudioSetting();
        }
    }
}
