using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoseHealTarget : MonoBehaviour
{
    [SerializeField]private GameObject healTargetPointer;

    [SerializeField] private Transform healTargetLeftPos;
    [SerializeField] private Transform healTargetRightPos;

    [SerializeField] private Human leftHuman;
    [SerializeField] private Human rightHuman;

    public static Human targetToHeal;
    
    public void ChangeTargetToLeft()
    {
        healTargetPointer.transform.position = healTargetLeftPos.position;

        swithcTarget(leftHuman);
    }

    public void ChangeTargetToRight()
    {
        healTargetPointer.transform.position = healTargetRightPos.position;

        swithcTarget(rightHuman);
    }

    private void swithcTarget(Human targetHuman)
    {
        targetToHeal = targetHuman;
    }

    void Start()
    {
        targetToHeal = leftHuman;
    }
}
