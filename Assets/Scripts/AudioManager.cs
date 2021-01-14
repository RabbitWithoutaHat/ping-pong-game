﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource[] AudioSources;

    private void Awake() {
        instance = this;
    }

    public void PlaySoundByName(string name)
    {
        foreach (var item in AudioSources)
        {
            if (item.gameObject.name == name)
            {
                item.pitch = Random.Range(.95f, 1.35f);
                item.volume = Random.Range(.85f, 1.25f);
                item.Play();
            }
        }
    }
}
