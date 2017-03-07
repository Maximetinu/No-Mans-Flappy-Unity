using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {
    [HideInInspector]
    public AudioSource backgroundMusic, deathEffect, jumpEffect, scoreEffect, turboEffect;
	void Start () {
        backgroundMusic = GetComponents<AudioSource>()[0];
        deathEffect = GetComponents<AudioSource>()[1];
        jumpEffect = GetComponents<AudioSource>()[2];
        scoreEffect = GetComponents<AudioSource>()[3];
        turboEffect = GetComponents<AudioSource>()[4];

        if (PlayerPrefs.GetString("music", "True") == false.ToString())
            backgroundMusic.Stop();
        if (PlayerPrefs.GetString("sound","True") == false.ToString())
            deathEffect.mute = jumpEffect.mute = scoreEffect.mute = turboEffect.mute = true;
    }
}
