using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    public enum GameState
    {
        InMenu,
        Fight,
        Walk,
        Chill,
        Dead,
        Pause,
        StartNewLevel
    }

    public GameState gameState;

    public void ChangeState(GameState gs)
    {
        gameState = gs;
    }
}
