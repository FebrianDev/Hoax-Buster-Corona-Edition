using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    private GameObject music;
    private AudioSource bgMusic;
    public Slider slider;
    void Start()
    {
        music = GameObject.FindWithTag("Music");
        if(music != null)
        {
            bgMusic = music.GetComponent<AudioSource>();
        }

        slider.value = PlayerPrefs.GetFloat("SliderMusic", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        bgMusic.volume = slider.value;
    }

    public void Back()
    {
        PlayerPrefs.SetFloat("SliderValue", slider.value);
        SceneManager.LoadScene("Main Menu");
    }
}
