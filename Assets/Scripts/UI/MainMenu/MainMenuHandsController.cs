using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuHandsController : MonoBehaviour
{
    public Animator handAnimator;

    public void MoveHand()
    {
        handAnimator.SetTrigger("Spell_2");
    }

}
