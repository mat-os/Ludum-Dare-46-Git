using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    public AnimationController girlLeftAnimationController;
    //public AnimationController girlRight;

    public Human girlLeft;

    public Vector2 walkTimeMinMax;

    public LevelSpawnManager levelSpawnManager;

    private GameStatus gameStatus;

    void Start()
    {
        gameStatus = GameInstance.Instance.gameStatus;

        if (gameStatus.gameState == GameStatus.GameState.StartNewLevel)
        {
            Walk();
        }
    }

    public void Walk()
    {
        gameStatus.gameState = GameStatus.GameState.Walk;

        girlLeftAnimationController.changeAnimState("GameState", (int)gameStatus.gameState);

        StartCoroutine(WalkRoutine());
    }

    public void Fight()
    {
        gameStatus.gameState = GameStatus.GameState.Fight;

        girlLeftAnimationController.changeAnimState("GameState", (int)gameStatus.gameState);

        levelSpawnManager.SpawnEnemies();

        girlLeft.FindTarget();
    }

    IEnumerator WalkRoutine()
    {
        yield return new WaitForSeconds(Random.Range(walkTimeMinMax.x, walkTimeMinMax.y));

        Fight();
    }

    public void GameFail()
    {
        gameStatus.gameState = GameStatus.GameState.Dead;

        GameInstance.Instance.failUiController.GameIsFailed();
    }
}
