using System.Globalization;
using UnityEngine;
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
    
    [SerializeField] private GameObject panelGameOver;
    
    public void UIPlayer()
    {
        credibilitasText.text = $"Credibilitas : {DataPlayer.Credibilitas.ToString()}";
        coinText.text = $"Coin : {DataPlayer.Coin.ToString()}";
        hoaxConfirmText.text = DataPlayer.HoaxConfirm.ToString();
        timerText.text = $"{Timer.Instance.minutes} : {Timer.Instance.seconds}";
    }

    public void PanelGameOver() => panelGameOver.SetActive(GameOver.Instance.IsGameOver);
    
}