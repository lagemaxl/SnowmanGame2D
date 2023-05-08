using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    [SerializeField]
    private Slider slider;

    Music music = null;

    void Start()
    {
        music = FindObjectOfType<Music>();
        slider.value = music.GetVolume();
    }

    public void UpdateVolume()
    {
        if (music != null)
            music.SetVolume(slider.value);
    }
}
