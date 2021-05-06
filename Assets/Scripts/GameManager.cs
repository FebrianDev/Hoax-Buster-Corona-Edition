using System;
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

   private void Start()
   {
      DataPlayer.Coin = 0;
      DataPlayer.Credibilitas = 8;
      DataPlayer.HoaxConfirm = 0;
      
      Timer.Instance.time = 300;

      Time.timeScale = 1f;
   }

   private void Update()
   {
      PlayerMovement.Instance.InputJoystick();
      Timer.Instance.SetTimer();
      UIManager.Instance.UIPlayer();
      UIManager.Instance.PanelGameOver();
   }

   private void FixedUpdate()
   {
      PlayerMovement.Instance.Movement();
   }
   
};
