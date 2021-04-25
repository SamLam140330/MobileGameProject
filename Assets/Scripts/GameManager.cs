﻿using UnityEngine;

public class GameManager : SingletonManager<GameManager>
{
    [HideInInspector] public int highestScore = 0;
    [HideInInspector] public bool isAudioOn = true;
    [HideInInspector] public bool isPause = false;
    public AudioSource itemPickupBgm = null;
    public AudioSource stoneDestroyBgm = null;
    public Sprite[] images = null;

    public void PlaySound(int type)
    {
        if (type == 0)
        {
            itemPickupBgm.Play();
        }
        else
        {
            stoneDestroyBgm.Play();
        }
    }
}
