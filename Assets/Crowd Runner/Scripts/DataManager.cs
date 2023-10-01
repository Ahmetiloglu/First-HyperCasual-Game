using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    
    [Header("Coin Text")] 
    [SerializeField] private Text[] coinsTexts;
    private int coins;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
        
        
        coins = PlayerPrefs.GetInt("coins", 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateCoinsTexts();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateCoinsTexts()
    {
        foreach (Text coinText in coinsTexts)
        {
            coinText.text = coins.ToString();
        }
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        
        UpdateCoinsTexts();
        
        PlayerPrefs.SetInt("coins", coins);
    }
}
