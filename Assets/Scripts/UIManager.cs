using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject tipsPanel = null;
    [SerializeField] private GameObject pausePanel = null;
    [SerializeField] private GameObject pauseBtn = null;
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
        gameManager.isPause = false;
        Time.timeScale = 1f;
        UpdateScoreTxt();
        tipsPanel.SetActive(true);
        LeanTween.scale(tipsPanel, Vector3.one, 0f);
        pausePanel.SetActive(false);
        pauseBtn.SetActive(true);
        gameOverPanel.SetActive(true);
        LeanTween.scale(gameOverPanel, Vector3.zero, 0f);
    }

    private void Start()
    {
        CheckAudioSetting();
        StartCoroutine(ShowTips());
    }

    private IEnumerator ShowTips()
    {
        yield return new WaitForSecondsRealtime(2f);
        LeanTween.scale(tipsPanel, Vector3.zero, 1f);
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
        if (gameManager.isAudioOn == true)
        {
            explosionBgm.Play();
        }
        backgroundBgm.Stop();
        pausePanel.SetActive(false);
        pauseBtn.SetActive(false);
        gameOverScoreTxt.SetText("Your Score: " + (int)ObjectSpawnManager.Score);
        gameOverHigherScoreTxt.SetText("Higher Score: " + gameManager.highestScore);
        LeanTween.scale(gameOverPanel, Vector3.one, 1f).setEase(LeanTweenType.easeInOutBack);
    }

    public void OnPauseButtonClicked()
    {
        gameManager.isPause = true;
        if (gameManager.isAudioOn == true)
        {
            backgroundBgm.Pause();
        }
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnResumeButtonClicked()
    {
        Time.timeScale = 1f;
        gameManager.isPause = false;
        if (gameManager.isAudioOn == true)
        {
            backgroundBgm.Play();
        }
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
        }
        else
        {
            audioImage.sprite = gameManager.images[1];
            gameManager.isAudioOn = true;
        }
    }
}
