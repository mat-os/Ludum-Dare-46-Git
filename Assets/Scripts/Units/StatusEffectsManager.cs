using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectsManager : MonoBehaviour
{
    private Entity thisEntity;

    void Start()
    {
        thisEntity = gameObject.GetComponent<Entity>();
    }

    public void AddEffect(StatusEffectData effect, float timeOfEffect)
    {
        //BURNING
        if (effect.EffectType == StatusEffectData.effectsList.Burning && thisEntity.GetIsAlive())
        {
            StartCoroutine(DamageRoutine(effect.DamageOfEffect, effect.TimeOfEffect));

            GameInstance.Instance.particleSystemController.StartBurningEffect(thisEntity, timeOfEffect);

            thisEntity.GetComponent<HPSysytem>().GetHPBar().SetEffect(effect);
        }
    }

    IEnumerator DamageRoutine(float damageAmount, float timeOfEffect)
    {
        float t = 0;

        while (t < timeOfEffect || thisEntity.GetIsAlive() == true)
        {
            thisEntity.TakeDamage(damageAmount);
            yield return new WaitForFixedUpdate();
            t += Time.fixedDeltaTime;
        }
    }
}
