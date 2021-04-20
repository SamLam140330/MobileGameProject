using UnityEngine;

public class GameManager : SingletonManager<GameManager>
{
    [HideInInspector] public int highestScore = 0;
    [HideInInspector] public bool isAudioOn = true;
    public Sprite[] images = null;
}
