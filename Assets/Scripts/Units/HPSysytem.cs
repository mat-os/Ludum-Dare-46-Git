using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPSysytem : MonoBehaviour
{
    [SerializeField]private GameObject HPBarPrefab;
    [SerializeField] private Transform HPBarInstancePos;

    private float HPmax;
    private float HPamount;

    HPBar hpBar;

    void Start()
    {
        var hpBarObj = Instantiate(HPBarPrefab, HPBarInstancePos.position, Quaternion.identity);

        hpBarObj.transform.parent = this.gameObject.transform;

        hpBar = hpBarObj.GetComponent<HPBar>();

        hpBar.UpdateHPBar(HPmax, HPamount);
        
        StartCoroutine(startRoutine());
    }

    public void TakeDamage(float damageAmount)
    {
        HPamount -= damageAmount;

        if (hpBar == null)
        {
            Debug.Log("NULLLLLLLLLLLL   " + gameObject.name);

        }
        else
        {
            hpBar.UpdateHPBar(HPmax, HPamount);
        }
    }

    public void TakeHeal(float healAmount)
    {
        if (HPamount + healAmount >= HPmax)
        {
            HPamount = HPmax;
        }
        else
        {
            HPamount += healAmount;
        }

        hpBar.UpdateHPBar(HPmax, HPamount);
    }

    public float GetHPAmount()
    {
        return HPamount;
    }

    public void SetMaxHP(float _maxHP)
    {
        HPmax = _maxHP;
        HPamount = HPmax;
    }

    IEnumerator startRoutine()
    {
        yield return new WaitForSeconds(0.1f);

        hpBar.UpdateHPBar(HPmax, HPamount);
    }
}
