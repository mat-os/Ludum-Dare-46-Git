using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private HPSysytem hpSysytem;
    [SerializeField] private RuntimeAnimatorController normalController;
    [SerializeField] private RuntimeAnimatorController lowHPController;

    private Animator animator;

    private float startHP;

    void Start()
    {
        animator = GetComponent<Animator>();

        startHP = hpSysytem.GetHPAmount();
    }

    void Update()
    {
        if (hpSysytem.GetHPAmount() > startHP / 3)
        {
            animator.runtimeAnimatorController = normalController;
        }
        else
        {
            animator.runtimeAnimatorController = lowHPController;
        }
    }


    public void changeAnimState(string ParamName, int Value)
    {
        animator.SetInteger(ParamName, Value);
    }

    public void AttackAnimation()
    {
        animator.SetTrigger("NormHP_Attack");
    }
}
