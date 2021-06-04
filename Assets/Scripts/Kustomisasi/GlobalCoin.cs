using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalCoin : MonoBehaviour
{
    public static int COIN;
    [SerializeField] private Text textCoin;
    void Start()
    {
        COIN = PlayerPrefs.GetInt("COIN", 0);
    }

    // Update is called once per frame
    void Update()
    {
        textCoin.text = $"Coin : {COIN}";
    }
}
