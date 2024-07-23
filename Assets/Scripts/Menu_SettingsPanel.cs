using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_SettingsPanel : MonoBehaviour
{

    [SerializeField] GameObject settingsPanel;
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;
    // public AudioSource musicSource;
    // public AudioSource sfxSource;

    public GameSettings gameSettings;
    
    public void Open()
    {
        gameSettings = new GameSettings();

        //musicVolumeSlider.onValueChanged.AddListener(delegate { OnMusicVolumeChange(); });
        //sfxVolumeSlider.onValueChanged.AddListener(delegate { OnSfxVolumeChange(); });
        settingsPanel.SetActive(true);

        // AudioManager.Instance.UpdateMixerVolume();
        // AudioManager.Instance.UpdateMixerVolume();
        musicVolumeSlider.value = AudioOptionsManager.musicVolume;
        sfxVolumeSlider.value = AudioOptionsManager.soundEffectsVolume;
    }

    public void Close()
    {
        settingsPanel.SetActive(false);
    }

    // public void OnMusicVolumeChange()
    // {
    //     musicSource.volume = gameSettings.musicVolume = musicVolumeSlider.value;
    // }

    // public void OnSfxVolumeChange()
    // {
    //     sfxSource.volume = gameSettings.sfxVolume = sfxVolumeSlider.value;
    // }

    public void Play()
    {
        SceneManager.LoadScene(3);
    }
}
