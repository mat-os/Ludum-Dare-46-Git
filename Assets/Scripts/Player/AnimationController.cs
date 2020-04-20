using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private GameStatus gameStatus;
    private Animator animator;

    void Start()
    {
        gameStatus = GameInstance.Instance.gameStatus;

        animator = GetComponent<Animator>();
    }

    public void changeAnimState(string ParamName, int Value)
    {
        animator.SetInteger(ParamName, Value);
    }

    public void AttackAnimation()
    {
        animator.SetTrigger("LowHP_Attack");
    }
}
