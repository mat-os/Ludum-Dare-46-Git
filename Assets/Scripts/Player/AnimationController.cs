using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private RuntimeAnimatorController normalController;
    [SerializeField] private RuntimeAnimatorController lowHPController;

    private Animator animator;

    private float startHP;

    private Entity thisEntity;

    void Start()
    {
        thisEntity = gameObject.GetComponent<Entity>();

        animator = GetComponent<Animator>();

        startHP = thisEntity.GetHPAmount();
    }

    void Update()
    {
        if (thisEntity.GetHPAmount() > startHP / 3)
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
