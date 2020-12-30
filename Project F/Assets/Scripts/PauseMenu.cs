using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
	public static bool GameIsPaused = false;
    public static bool GameIsOptions = false;
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    public AudioMixerGroup Mixer;
    public AudioSource myFx;
    public AudioClip hoverFx;
    public AudioClip clickFx;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !HealthSystem.dead)
        {
            if (GameIsOptions) {
                Back();
            }
            else if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
	
	public void Resume()
	{
		pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
		GameIsPaused = false;
	}

	void Pause()     
	{
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}
	
	public void LoadMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("MainMenu");
	}

    public void Options()
    {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsOptions = true;
    }

    public void Back()
    {
        pauseMenuUI.SetActive(true);
        optionsMenuUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsOptions = false;
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

    public void QuitGame()
	{
		Application.Quit();
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
