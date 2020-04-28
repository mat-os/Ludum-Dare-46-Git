using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstance : MonoBehaviour
{
    public Transform popupText;

    public PlayerInput playerInput;
    public ManaController manaController;

    public GameStatus gameStatus;

    public GameplayController gameplayController;

    public FailUIController failUiController;

    public LevelSpawnManager levelSpawnManager;

    public ParticleSystemController particleSystemController;

    #region Awake
    public static GameInstance Instance;

    void Awake()
    {
        if (Instance == null)
        {
            //DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    #endregion
}
