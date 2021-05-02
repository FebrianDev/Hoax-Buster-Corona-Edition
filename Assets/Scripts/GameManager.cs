using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

   private float timer;

   private void Start()
   {
      DataPlayer.Coin = 0;
      timer = 300;
   }

   private void Update()
   {
      SetTimer();
      Debug.Log(DataPlayer.Coin);
   }

   private void SetTimer()
   {
      timer -= Time.unscaledDeltaTime;
      
      float minutes = Mathf.FloorToInt(timer / 60);
      float seconds = Mathf.FloorToInt(timer % 60);

      Debug.Log($"{minutes:00}:{seconds:00}");
   }

   
   private bool IsGameOver => (timer <= 0) ? true : false;
   
};
