using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
	public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public AudioMixerGroup Mixer;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !HealthSystem.dead)
        {
            if (GameIsPaused)
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

    public void ToggleMusic(bool enabled)
    {
        float value;
        Mixer.audioMixer.GetFloat("MusicVolume", out value);
        if (value != 0)
            Mixer.audioMixer.SetFloat("MusicVolume", 0);
        else
            Mixer.audioMixer.SetFloat("MusicVolume", -80);
    }

    public void ChangeVolume(float master)
    {
        if (master > 0.5f)
            Mixer.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-40, 0, master));
        else if (master > 0.25f)
            Mixer.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-60, 20, master));
        else
            Mixer.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80, 80, master));
    }

    public void QuitGame()
	{
		Application.Quit();
	}
}
