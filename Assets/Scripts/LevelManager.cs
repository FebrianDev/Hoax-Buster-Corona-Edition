using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

}