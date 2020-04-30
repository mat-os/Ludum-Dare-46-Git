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

    public ChillManager сhillManager;

    private GameStatus gameStatus;

    void Start()
    {
        gameStatus = GameInstance.Instance.gameStatus;

        if (gameStatus.gameState == GameStatus.GameState.StartNewLevel)
        {
            WalkAndSearch();
        }
    }


    //Когда мы нашли что-то
    private void FindSomething()
    {
        if (GameInstance.Instance.levelSpawnManager.isLevelEnd() == true)
        {
            Chill();
        }
        else
        {
            FindNewRoom();

            if (levelSpawnManager.IsNewRoomWithEnemy())
            {
                Fight();
            }
            else
            {
                OnSpecialRoomEvent();
            }
        }
    }

    //Идем
    public void WalkAndSearch()
    {
        gameStatus.gameState = GameStatus.GameState.Walk;

        ChangeAnimStateGirls();

        StartCoroutine(WalkRoutine());
    }

    public void FindNewRoom()
    {
        levelSpawnManager.SpawnNewStage();
    }

    //Начинаем бой
    public void Fight()
    {
        gameStatus.gameState = GameStatus.GameState.Fight;

        ChangeAnimStateGirls();


        girlLeft.FindTarget();

        girlRight.FindTarget();
    }

    //Отдых в конце уровня на алтаре
    public void Chill()
    {
        gameStatus.gameState = GameStatus.GameState.Chill;

        ChangeAnimStateGirls();

        сhillManager.StartChill();
    }

    //Нашли спец. комнату
    public void OnSpecialRoomEvent()
    {
        gameStatus.gameState = GameStatus.GameState.Chill;

        ChangeAnimStateGirls();

        Debug.Log("ASDASD");
    }

    IEnumerator WalkRoutine()
    {
        yield return new WaitForSeconds(Random.Range(walkTimeMinMax.x, walkTimeMinMax.y));

        FindSomething();

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
