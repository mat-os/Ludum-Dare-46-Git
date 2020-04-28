using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningParticles : MonoBehaviour
{
    private ParticleSystem ps;
    ParticleSystem.ShapeModule shapeModule;

    private SpriteRenderer sr;

    private float timeOfDestroy;
    private float t;

    public void Init(SpriteRenderer spriteRenderer, float timeToDestroy)
    {
        sr = spriteRenderer;
        timeOfDestroy = timeToDestroy;
    }

    void Start()
    {
        ps = gameObject.GetComponent<ParticleSystem>();

        shapeModule = ps.shape;
    }

    void FixedUpdate()
    {
        shapeModule.sprite = sr.sprite;

        if (t < timeOfDestroy)
        {
            t += Time.fixedDeltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
