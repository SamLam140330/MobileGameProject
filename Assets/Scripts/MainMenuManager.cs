using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene(1);
    }

    public void OnScoreButtonClicked()
    {

    }

    public void OnAudioButtonClicked()
    {

    }

    public void OnShareButtonClicked()
    {

    }

    public void OnExitButtonClicked()
    {
        Application.Quit();
    }
}
