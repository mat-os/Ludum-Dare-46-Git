using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimBG : MonoBehaviour
{
    public float animSpeed;

    public Sprite[] wallSprites;

    private SpriteRenderer sr;

    private bool isMoving;
    private bool animStart;

    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (GameInstance.Instance.gameStatus.gameState == GameStatus.GameState.Walk && !animStart)
        {
            MoveWall();

            animStart = true;
        }
        else if(GameInstance.Instance.gameStatus.gameState != GameStatus.GameState.Walk)
        {
            StopWall();

            animStart = false;
        }
    }

    public void MoveWall()
    {
        isMoving = true;
        StartCoroutine(moveWallRoutine(isMoving));
    }

    public void StopWall()
    {
        isMoving = false;
        StopAllCoroutines();
    }

    IEnumerator moveWallRoutine(bool _isMoving)
    {
        var tempSptiteCount = 0;

        while (_isMoving)
        {
            sr.sprite = wallSprites[tempSptiteCount];

            tempSptiteCount++;

            if (tempSptiteCount == wallSprites.Length)
            {
                tempSptiteCount = 0;
            }

            yield return new WaitForSeconds(animSpeed);
        }

        yield return null;
    }
}
