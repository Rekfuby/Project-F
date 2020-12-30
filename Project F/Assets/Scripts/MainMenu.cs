using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject settingsMenuUI;
    public AudioMixerGroup Mixer;
    public AudioSource myFx;
    public AudioClip hoverFx;
    public AudioClip clickFx;

    public void LoadLevel(string levelName) 
	{
		SceneManager.LoadSceneAsync(levelName);
	}
	
	public void ExitGame() 
	{
		Application.Quit();
	}
	
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Back();
        }
    }

    public void Settings()
    {
        mainMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);
    }

    public void Back()
    {
        mainMenuUI.SetActive(true);
        settingsMenuUI.SetActive(false);
    }

    public void ToggleMusic(bool enabled)
    {
        float value;
        Mixer.audioMixer.GetFloat("MusicVolume", out value);
        if (value != 0)
            Mixer.audioMixer.SetFloat("MusicVolume", 0);
        else
            Mixer.audioMixer.SetFloat("MusicVolume", -80);
    }

    public void ChangeVolume(Slider master)
    {
        if (master.value > 0.5f)
            Mixer.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-40, 0, master.value));
        else if (master.value > 0.25f)
            Mixer.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-60, 20, master.value));
        else
            Mixer.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80, 80, master.value));
    }

    public void HoverSound()
    {
        myFx.PlayOneShot(hoverFx);
    }

    public void ClickSound()
    {
        myFx.PlayOneShot(clickFx);
    }
}
