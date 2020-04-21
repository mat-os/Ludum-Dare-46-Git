using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyAnimController : MonoBehaviour
{
    public SpriteRenderer sr;

    public Animator animator;

    void Start()
    {
        sr.color = new Color(1,1,1,0);

        sr.DOFade(1, 0.5f);
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
