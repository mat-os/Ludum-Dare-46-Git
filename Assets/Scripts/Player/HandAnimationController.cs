using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void PlayHandAnim(int animNumber)
    {
        animator.SetTrigger("Spell_" + animNumber);
    }

}
