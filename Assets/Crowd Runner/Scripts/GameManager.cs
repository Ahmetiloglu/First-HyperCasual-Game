using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private GameState gameState;
    public static Action<GameState> onGameStateChanged;
    public enum GameState
    {
        Menu, Game, LevelComplete, Gameover
    }

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
       // PlayerPrefs.DeleteAll();  use one time then delete this line
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGameState(GameState gameState)
    {
        this.gameState = gameState;
        onGameStateChanged?.Invoke(gameState);
        
        Debug.Log("Game State changed to: " + gameState);
    }

    public bool IsGameState()
    {
        return gameState == GameState.Game;
    }
    
}
