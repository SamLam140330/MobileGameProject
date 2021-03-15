using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu = null;

    private void Start()
    {
        Time.timeScale = 1f;
        _pauseMenu.SetActive(false);
    }

    public void OnPauseButtonClicked()
    {
        Time.timeScale = 0f;
        _pauseMenu.SetActive(true);
    }

    public void OnResumeButoonClicked()
    {
        Time.timeScale = 1f;
        _pauseMenu.SetActive(false);
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

    }
}
