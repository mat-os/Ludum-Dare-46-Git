using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyAnimController : MonoBehaviour
{
    public SpriteRenderer sr;

    private GameStatus gameStatus;

    private Animator animator;

    void Start()
    {
        gameStatus = GameInstance.Instance.gameStatus;

        animator = GetComponent<Animator>();
    }

    public void AttackAnimation()
    {
        animator.SetTrigger("Attack");
    }
    public void DeadAnim()
    {
        sr.DOFade(0,0.5f);
    }
}
