using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject tipsPanel = null;
    [SerializeField] private GameObject pausePanel = null;
    [SerializeField] private GameObject gameOverPanel = null;
    [SerializeField] private Image audioImage = null;
    [SerializeField] private TextMeshProUGUI scoreTxt = null;
    [SerializeField] private TextMeshProUGUI gameOverScoreTxt = null;
    [SerializeField] private TextMeshProUGUI gameOverHigherScoreTxt = null;
    [SerializeField] private AudioSource backgroundBgm = null;
    [SerializeField] private AudioSource explosionBgm = null;
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
        StartCoroutine(ShowTips());
    }

    private IEnumerator ShowTips()
    {
        tipsPanel.SetActive(true);
        yield return new WaitForSecondsRealtime(2f);
        tipsPanel.SetActive(false);
    }

    private void CheckAudioSetting()
    {
        if (gameManager.isAudioOn == true)
        {
            audioImage.sprite = gameManager.images[1];
            backgroundBgm.Play();
        }
        else
        {
            audioImage.sprite = gameManager.images[0];
            backgroundBgm.Stop();
        }
    }

    public void UpdateScoreTxt()
    {
        scoreTxt.SetText("Score: " + (int)ObjectSpawnManager.Score);
    }

    public void GameOver()
    {
        if (GameManager.Instance.isAudioOn == true)
        {
            explosionBgm.Play();
        }
        backgroundBgm.Stop();
        pausePanel.SetActive(false);
        gameOverScoreTxt.SetText("Your Score: " + (int)ObjectSpawnManager.Score);
        gameOverHigherScoreTxt.SetText("Higher Score: " + gameManager.highestScore);
        gameOverPanel.SetActive(true);
    }

    public void OnPauseButtonClicked()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void OnResumeButtonClicked()
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
