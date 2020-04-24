using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    private Human human;

    void Start()
    {
        human = GetComponent<Human>();
    }

    public void ChangeArmor(float armor, float timeOfActive)
    {
        StartCoroutine(changeArmorRoutine(armor, timeOfActive));
    }

    IEnumerator changeArmorRoutine(float armor, float timeOfActive)
    {
        var startArmor = human.GetArmorAmount();

        human.SetArmorAmount(armor);

        gameObject.GetComponent<ShildHPBarManager>().ActivateShield();

        yield return new WaitForSeconds(timeOfActive);

        gameObject.GetComponent<ShildHPBarManager>().DectivateShield();

        human.SetArmorAmount(startArmor);

        yield return null;
    }

    public void ChangeAttackRate(float attackRate, float timeOfActive)
    {
        StartCoroutine(ChangeAttackRateRoutine(attackRate, timeOfActive));
    }

    IEnumerator ChangeAttackRateRoutine(float attackRate, float timeOfActive)
    {
        var startRate = human.GetAttackRate();

        human.SetAttackRate(startRate / 2);

        //gameObject.GetComponent<ShildHPBarManager>().ActivateShield();

        yield return new WaitForSeconds(timeOfActive);

        //gameObject.GetComponent<ShildHPBarManager>().DectivateShield();

        human.SetAttackRate(startRate);

        yield return null;
    }
}
