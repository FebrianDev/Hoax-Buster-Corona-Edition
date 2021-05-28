using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
   public class MainMenu : MonoBehaviour
   {
      public void StartChooseLevel()
      {
         SceneManager.LoadScene("ChooseLevel");
      }

      public void Options()
      {
         SceneManager.LoadScene("Options");
      }

      public void CovidInfo()
      {
         SceneManager.LoadScene("MenuInfoCovid");
      }

      public void Customization()
      {
         SceneManager.LoadScene("Customization");
      }
   }
}
