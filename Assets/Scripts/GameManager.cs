using UnityEngine;

public class GameManager : SingletonManager<GameManager>
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
