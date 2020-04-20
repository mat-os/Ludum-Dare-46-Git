using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    public AnimationController girlLeftAnimationController;
    public AnimationController girlRightAnimationController;

    public Human girlLeft;
    public Human girlRight;

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

        ChangeAnimStateGirls();

        StartCoroutine(WalkRoutine());
    }

    private void Fight()
    {
        if (GameInstance.Instance.levelSpawnManager.isLevelEnd() == true)
        {
            Chill();
        }
        else
        {
            gameStatus.gameState = GameStatus.GameState.Fight;

            ChangeAnimStateGirls();

            levelSpawnManager.SpawnEnemies();

            girlLeft.FindTarget();

            girlRight.FindTarget();
        }
    }

    public void Chill()
    {
        gameStatus.gameState = GameStatus.GameState.Chill;

        ChangeAnimStateGirls();

        Debug.Log("WE ARE CHILL");
    }

    IEnumerator WalkRoutine()
    {
        yield return new WaitForSeconds(Random.Range(walkTimeMinMax.x, walkTimeMinMax.y));

        Fight();

        yield return null;
    }

    public void GameFail()
    {
        gameStatus.gameState = GameStatus.GameState.Dead;

        GameInstance.Instance.failUiController.GameIsFailed();
    }

    private void ChangeAnimStateGirls()
    {
        girlLeftAnimationController.changeAnimState("GameState", (int)gameStatus.gameState);

        girlRightAnimationController.changeAnimState("GameState", (int)gameStatus.gameState);
    }
}
