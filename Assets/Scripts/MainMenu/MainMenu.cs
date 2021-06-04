using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
   public class MainMenu : MonoBehaviour
   {
      [SerializeField] private GameObject musicObject;
      private GameObject music;
      private AudioSource bgMusic;
      private void Start()
      {
         music = GameObject.FindWithTag("Music");
         if (music == null)
         {
            musicObject.SetActive(true);
            musicObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("SliderMusic", 1);
         }
      }

      public void StartChooseLevel()
      {
         DontDestroyOnLoad(musicObject);  
         SceneManager.LoadScene("ChooseLevel");
      }

      public void Options()
      {
         DontDestroyOnLoad(musicObject);  
         SceneManager.LoadScene("Options");
      }

      public void CovidInfo()
      {
         DontDestroyOnLoad(musicObject);  
         SceneManager.LoadScene("MenuInfoCovid");
      }

      public void Customization()
      {
         DontDestroyOnLoad(musicObject);  
         SceneManager.LoadScene("Customization");
      }
   }
}
