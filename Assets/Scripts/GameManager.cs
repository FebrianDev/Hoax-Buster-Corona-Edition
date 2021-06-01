﻿using System;
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

   [HideInInspector] public bool isPause;

   [SerializeField] private int targetHoax;

   private void Start()
   {
      isPause = false;
      
      DataPlayer.Coin = 0;
      DataPlayer.Credibilitas = 8;
      DataPlayer.HoaxConfirm = 0;

      Time.timeScale = 1f;
   }

   private void Update()
   {
      PlayerMovement.Instance.InputJoystick();
      Timer.Instance.SetTimer();
      UIManager.Instance.UIPlayer();

      if (Input.GetKey(KeyCode.C))
      {
         PlayerPrefs.DeleteAll();
      }
   }

   private void FixedUpdate()
   {
      PlayerMovement.Instance.Movement();
   }

   public bool GameWin => DataPlayer.HoaxConfirm == targetHoax && DataPlayer.Credibilitas != 0;

};
