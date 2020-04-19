using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    [SerializeField]private TMP_Text HPtext;

    public void UpdateHPBar(float maxHP, float HPAmount)
    {
       HPtext.text = maxHP + "/" + HPAmount;
    }
}
