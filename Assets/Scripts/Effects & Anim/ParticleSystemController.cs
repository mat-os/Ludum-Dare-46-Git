using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemController : MonoBehaviour
{
    [SerializeField]private GameObject burningParticleSystemGO;
    private ParticleSystem.ShapeModule shapeModule;

    private SpriteRenderer sr;

    public void StartBurningEffect(Entity entityWithEffect, float timeToDestroy)
    {
        GameObject burningEffect = Instantiate(burningParticleSystemGO, entityWithEffect.transform.position, Quaternion.identity);
        burningEffect.GetComponent<BurningParticles>().Init(entityWithEffect.GetComponentInChildren<SpriteRenderer>(), timeToDestroy);
    }
}
