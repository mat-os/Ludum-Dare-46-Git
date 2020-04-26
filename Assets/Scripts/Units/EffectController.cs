using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    private Human human;

    private HPBarManager hpBarManager;

    void Start()
    {
        human = GetComponent<Human>();

        hpBarManager = GetComponent<HPBarManager>();
    }

    //Просто устанавливаем новое значение вместо прежденго, потом оно меняется на прежнее
    public void ChangeArmor(float armor, float timeOfActive)
    {
        StartCoroutine(changeArmorRoutine(armor, timeOfActive));
    }

    IEnumerator changeArmorRoutine(float armor, float timeOfActive)
    {
        var startArmor = human.GetArmorAmount();

        human.SetArmorAmount(startArmor + armor);

        hpBarManager.ActivateShield();

        yield return new WaitForSeconds(timeOfActive);

        hpBarManager.DectivateShield();

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

        human.SetAttackRate(startRate * attackRate);

        //gameObject.GetComponent<HPBarManager>().ActivateShield();

        yield return new WaitForSeconds(timeOfActive);

        //gameObject.GetComponent<HPBarManager>().DectivateShield();

        human.SetAttackRate(startRate);

        yield return null;
    }
}
