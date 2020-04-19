using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoseHealTarget : MonoBehaviour
{
    [SerializeField]private GameObject healTargetPointer;

    [SerializeField] private Transform healTargetLeftPos;
    [SerializeField] private Transform healTargetRightPos;

    public void ChangeTargetToLeft()
    {
        healTargetPointer.transform.position = healTargetLeftPos.position;
    }
    public void ChangeTargetToRight()
    {
        healTargetPointer.transform.position = healTargetRightPos.position;
    }
}
