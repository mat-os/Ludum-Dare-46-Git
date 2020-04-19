using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPSysytem : MonoBehaviour
{
    private float HPmax = 100;
    private float HPamount = 100;

    void Start()
    {
        Debug.Log("SystemInit");
        gameObject.AddComponent<HPBar>();
    }

    public void GetDamage(float damageAmount)
    {
        HPamount -= damageAmount;

        Debug.Log("Get damage" + damageAmount);
    }

    public float GetHPAmount()
    {
        return HPamount;
    }
}
