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

    [SerializeField] private Color inactiveColor;

    public static Human targetToHeal;

    public static Human[] bothHuman;
    
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
        targetToHeal.GetComponentInChildren<SpriteRenderer>().color = inactiveColor;

        targetToHeal.GetComponent<HPSysytem>().GetHPBar().ChangeSpritesActive(false, inactiveColor);

        targetToHeal = targetHuman;

        targetToHeal.GetComponentInChildren<SpriteRenderer>().color = Color.white;

        targetToHeal.GetComponent<HPSysytem>().GetHPBar().ChangeSpritesActive(true, Color.white);
    }

    void Start()
    {
        rightHuman.GetComponentInChildren<SpriteRenderer>().color = inactiveColor;

        rightHuman.GetComponent<HPSysytem>().GetHPBar().ChangeSpritesActive(false, inactiveColor);

        targetToHeal = leftHuman;

        bothHuman = new Human[2];

        bothHuman[0] = leftHuman;
        bothHuman[1] = rightHuman;
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            ChangeTargetToRight();
        }
        else if (Input.GetAxis("Horizontal") < -0.1f)
        {
            ChangeTargetToLeft();
        }
    }
}
