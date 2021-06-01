using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Singleton
    private static UIManager _uiManager;
    public static UIManager Instance
    {
        get
        {
            if (_uiManager == null)
            {
                _uiManager = FindObjectOfType<UIManager>();
            }

            return _uiManager;
        }
    }
    #endregion
    
    [Header("Timer")]
    [SerializeField] private Text timerText;

    [Header("UI Player")]
    [SerializeField] private Text credibilitasText;
    [SerializeField] private Text coinText;
    [SerializeField] private Text hoaxConfirmText;

    [Header("Panel")] 
    [SerializeField] private GameObject panelGameOver;
    [SerializeField] private GameObject  panelWin;
    [SerializeField] private GameObject  panelPause;

    [Header("Button")] 
    [SerializeField] private GameObject pause;

    private void Start()
    {
        pause.SetActive(true);
        
        panelPause.SetActive(false);
        panelGameOver.SetActive(false);
        panelWin.SetActive(false);
    }

    private void Update()
    {
        if (GameOver.Instance.IsGameOver)
        {
            timerText.text = $"{0} : {00}";
            pause.SetActive(false);
            Time.timeScale = 0f;
            panelGameOver.SetActive(true);
        }

        if (GameManager.Instance.GameWin)
        {
            panelWin.SetActive(true);
            Time.timeScale = 0f;
        }
        
    }

    public void UIPlayer()
    {
        credibilitasText.text = $"{DataPlayer.Credibilitas.ToString()}";
        coinText.text = $"{DataPlayer.Coin.ToString()}";
        hoaxConfirmText.text = DataPlayer.HoaxConfirm.ToString();
        timerText.text = $"{Timer.Instance.minutes} : {Timer.Instance.seconds}";
    }

    public void Pause()
    {
        GameManager.Instance.isPause = true;
        Time.timeScale = 0f;
        panelPause.SetActive(true);
    }

    public void Resume()
    {
        GameManager.Instance.isPause = false;
        Time.timeScale = 1f; 
        panelPause.SetActive(false);
    }

    public void Exit()
    {
        GameManager.Instance.isPause = false;
        Time.timeScale = 1f; 
        panelGameOver.SetActive(false);
        panelPause.SetActive(false);
        SceneManager.LoadScene("ChooseLevel");
    }
    
    public void Restart()
    {
        GameManager.Instance.isPause = false;
        Time.timeScale = 1f; 
        panelGameOver.SetActive(false);
        panelPause.SetActive(false);
        SceneManager.LoadScene("Level 1-1");
    }

    public void NextLevel()
    {
        PlayerPrefs.SetString("Level2", "Level2");
        GameManager.Instance.isPause = false;
        Time.timeScale = 1f; 
        panelGameOver.SetActive(false);
        panelPause.SetActive(false);
        SceneManager.LoadScene("ChooseLevel");
    }
}