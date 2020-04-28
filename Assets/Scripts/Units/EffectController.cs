using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    public GameObject shield;

    private Human human;

    void Start()
    {
        human = GetComponent<Human>();
    }

    //Просто устанавливаем новое значение, потом оно меняется на прежнее
    public void ChangeArmor(float armor, float timeOfActive)
    {
        StartCoroutine(changeArmorRoutine(armor, timeOfActive));
    }

    IEnumerator changeArmorRoutine(float armor, float timeOfActive)
    {
        var startArmor = human.GetArmorAmount();

        human.SetArmorAmount(startArmor + armor);

        shield.SetActive(true);

        yield return new WaitForSeconds(timeOfActive);

        shield.SetActive(false);

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

        human.SetAttackRate(startRate - (startRate / attackRate));

        //gameObject.GetComponent<HPBarManager>().ActivateShield();

        yield return new WaitForSeconds(timeOfActive);

        //gameObject.GetComponent<HPBarManager>().DectivateShield();

        human.SetAttackRate(startRate);

        yield return null;
    }
}
