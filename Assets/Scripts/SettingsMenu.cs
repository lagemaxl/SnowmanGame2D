using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;
    [SerializeField]
    private Slider musicSlider;

    void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("Volume", 0.75f);
    }

    public void SetMusic(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
}
