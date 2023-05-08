using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;

    void Start()
    {
      
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}
