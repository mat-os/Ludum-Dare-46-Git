using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBarStatusPanel : MonoBehaviour
{
    [SerializeField] private GameObject effectGO;

    private SpriteRenderer sr;

    public void SetEffect(Sprite newSpriteEffect, float timeOfEffect)
    {
        GameObject newEffect = Instantiate(effectGO, transform.position, Quaternion.identity);
        newEffect.transform.parent = this.transform;
        newEffect.GetComponent<SpriteRenderer>().sprite = newSpriteEffect;

        newEffect.transform.localScale = Vector3.one;
        
    }

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
}
