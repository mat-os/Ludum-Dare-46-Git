using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPSysytem : MonoBehaviour
{
    [SerializeField]private GameObject HPBarPrefab;
    [SerializeField] private Transform HPBarInstancePos;
    
    private HPBar hpBar;

    private Entity thisEntity;

    void Start()
    {
        thisEntity = gameObject.GetComponent<Entity>();

        var hpBarObj = Instantiate(HPBarPrefab, HPBarInstancePos.position, Quaternion.identity);

        hpBarObj.transform.parent = this.gameObject.transform;

        hpBar = hpBarObj.GetComponent<HPBar>();

        hpBar.UpdateHPBar(thisEntity.GetHPmax(), thisEntity.GetHPAmount());
        
        StartCoroutine(startRoutine());
    }

    public void TakeDamage(float damageAmount)
    {
        thisEntity.SetHPAmount(thisEntity.GetHPAmount() - damageAmount);

        hpBar.UpdateHPBar(thisEntity.GetHPmax(), thisEntity.GetHPAmount());
    }

    public void TakeHeal(float healAmount)
    {
        if (thisEntity.GetHPAmount() + healAmount >= thisEntity.GetHPmax())
        {
            thisEntity.SetHPAmount(thisEntity.GetHPmax());
        }
        else
        {
            thisEntity.SetHPAmount(thisEntity.GetHPAmount() + healAmount);
        }

        hpBar.UpdateHPBar(thisEntity.GetHPmax(), thisEntity.GetHPAmount());

        TextPopup.CreateHealPopup(transform.position, healAmount);
    }

    IEnumerator startRoutine()
    {
        yield return new WaitForSeconds(0.1f);

        hpBar.UpdateHPBar(thisEntity.GetHPmax(), thisEntity.GetHPAmount());
    }

    public HPBar GetHPBar()
    {
        return hpBar;
    }
}
