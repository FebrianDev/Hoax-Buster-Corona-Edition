using UnityEngine;

public class Timer : MonoBehaviour
{
    private static Timer _timer;
    public static Timer Instance
    {
        get
        {
            if (_timer == null)
            {
                _timer = FindObjectOfType<Timer>();
            }
            return _timer;
        }
    }

    public float time; 
    [HideInInspector] public float minutes;
    [HideInInspector] public float seconds;
    public void SetTimer()
    {
        time -= Time.unscaledDeltaTime;
      
        minutes = Mathf.FloorToInt(time / 60);
        seconds = Mathf.FloorToInt(time % 60);
    }

}