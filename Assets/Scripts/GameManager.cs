using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   private static GameManager _instance;
   public static GameManager Instance
   {
      get
      {
         if (_instance == null)
         {
            _instance = FindObjectOfType<GameManager>();
         }
         return _instance;
      }
   }
   
   [Header("Timer")]
   [SerializeField] private Text timerText;
   private float timer;
   
   [Header("UI Player")]
   [SerializeField] private Text credibilitasText;
   [SerializeField] private Text coinText;
   [SerializeField] private Text hoaxConfirmText;
   [SerializeField] private GameObject panelGameOver;

   private void Start()
   {
      DataPlayer.Coin = 0;
      DataPlayer.Credibilitas = 8;
      DataPlayer.HoaxConfirm = 0;
      
      timer = 300;
      
      panelGameOver.SetActive(false);
      
      Time.timeScale = 1f;
   }

   private void Update()
   {
      SetTimer();
      UIPlayer();

      if (IsGameOver)
      {
         Time.timeScale = 0f;
        panelGameOver.SetActive(true);
      }
   }

   private void SetTimer()
   {
      timer -= Time.unscaledDeltaTime;
      
      float minutes = Mathf.FloorToInt(timer / 60);
      float seconds = Mathf.FloorToInt(timer % 60);

      timerText.text = $"{minutes:00}:{seconds:00}";
   }

   private void UIPlayer()
   {
      credibilitasText.text = $"Credibilitas : {DataPlayer.Credibilitas.ToString()}";
      coinText.text = $"Coin : {DataPlayer.Coin.ToString()}";
      hoaxConfirmText.text = DataPlayer.HoaxConfirm.ToString();
   }
   
   //if timer <= 0 or Credibilitas == 0 then return true else return false 
   private bool IsGameOver => (timer <= 0 || DataPlayer.Credibilitas == 0) ? true : false;

   public void Restart()
   {
      SceneManager.LoadScene("SampleScene");
   }

};
