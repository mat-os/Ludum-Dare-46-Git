using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPSysytem : MonoBehaviour
{
    [SerializeField]private GameObject HPBarPrefab;
    [SerializeField] private Transform HPBarInstancePos;

    private float HPmax = 100;
    private float HPamount = 100;

    private HPBar hpBar;

    void Start()
    {
        Debug.Log("SystemInit");

        var hpBarObj = Instantiate(HPBarPrefab, HPBarInstancePos.position, Quaternion.identity);

        hpBarObj.transform.parent = this.gameObject.transform;

        hpBar = hpBarObj.GetComponent<HPBar>();

        hpBar.UpdateHPBar(HPmax, HPamount);
    }

    public void TakeDamage(float damageAmount)
    {
        HPamount -= damageAmount;

        hpBar.UpdateHPBar(HPmax, HPamount);

        Debug.Log(gameObject.name + " Get damage " + damageAmount);

        Debug.Log(gameObject.name + " Total Health = " + HPamount);
    }

    public float GetHPAmount()
    {
        return HPamount;
    }
}
