using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel = null;
    [SerializeField] private GameObject scorePanel = null;
    [SerializeField] private TextMeshProUGUI scoreTxt = null;
    [SerializeField] private Image audioImage = null;
    [SerializeField] private AudioSource[] audioSources = null;
    private GameManager gameManager = null;

    private void Start()
    {
        gameManager = GameManager.Instance;
        gameManager.highestScore = PlayerPrefs.GetInt("HighestScore", 0);
        scoreTxt.SetText("The highest score: " + gameManager.highestScore);
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

    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene(1);
    }

    public void OnScoreButtonClicked()
    {
        menuPanel.SetActive(false);
        scorePanel.SetActive(true);
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
        menuPanel.SetActive(true);
    }
}
