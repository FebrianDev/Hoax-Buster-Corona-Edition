using UnityEngine;

public class GameOver : MonoBehaviour
{
    
    #region Singleton
    private static GameOver _gameOver;
    public static GameOver Instance
    {
        get
        {
            if ( _gameOver == null)
            {
                _gameOver = FindObjectOfType<GameOver>();
            }

            return  _gameOver;
        }
    }
    #endregion


    //if timer <= 0 or Credibilitas == 0 then return true else return false 
    public bool IsGameOver => (Timer.Instance.time <= 0 || DataPlayer.Credibilitas == 0) ? true : false;
}