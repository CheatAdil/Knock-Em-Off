using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundManager : MonoBehaviour
{
	public float soundVolume;
	private float musicVolume;
	[SerializeField] private Slider soundSlider;
	[SerializeField] private Slider musicSlider;

	[SerializeField] private AudioSource musicPlayer;
	private void Start()
	{
		soundVolume = PlayerPrefs.GetFloat("SoundVolume");
		musicVolume = PlayerPrefs.GetFloat("MusicVolume");

		soundSlider.value = soundVolume;
		musicSlider.value = musicVolume;
	}
	public void UpdateSoundVolume()
	{
		soundVolume = soundSlider.value;
		PlayerPrefs.SetFloat("SoundVolume", soundVolume);
	}
	public void UpdateMusicVolume()
	{
		musicPlayer.volume = musicSlider.value;
		PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
	}
	public void Restart()
	{
		Time.timeScale = 1f;
		UnityEngine.SceneManagement.SceneManager.LoadScene(0);
	}
	public void PauseGame()
	{
		if (Time.timeScale == 1) Time.timeScale = 0f;
		else Time.timeScale = 1f;
	}
}
