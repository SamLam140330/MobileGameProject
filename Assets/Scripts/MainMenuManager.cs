using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel = null;
    [SerializeField] private GameObject scorePanel = null;
    [SerializeField] private GameObject creditPanel = null;
    [SerializeField] private TextMeshProUGUI scoreTxt = null;
    [SerializeField] private Image audioImage = null;
    [SerializeField] private AudioSource audioSources = null;
    private GameManager gameManager = null;

    private void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    private void Start()
    {
        gameManager = GameManager.Instance;
        gameManager.highestScore = PlayerPrefs.GetInt("HighestScore", 0);
        scoreTxt.SetText("The highest Score: " + gameManager.highestScore);
        CheckAudioSetting();
    }

    private void CheckAudioSetting()
    {
        if (gameManager.isAudioOn == true)
        {
            audioImage.sprite = gameManager.images[1];
            audioSources.Play();
        }
        else
        {
            audioImage.sprite = gameManager.images[0];
            audioSources.Stop();
        }
    }

    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene(1);
    }

    public void OnScoreButtonClicked()
    {
        menuPanel.SetActive(false);
        scorePanel.SetActive(true);
    }

    public void OnCreditButtonClicked()
    {
        menuPanel.SetActive(false);
        creditPanel.SetActive(true);
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

    public void OnExitButtonClicked()
    {
        Application.Quit();
    }

    public void OnBackClicked()
    {
        scorePanel.SetActive(false);
        creditPanel.SetActive(false);
        menuPanel.SetActive(true);
    }
}
