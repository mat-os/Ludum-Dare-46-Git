using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EffectData", menuName = "EffectType Data", order = 51)]
public class StatusEffectData : ScriptableObject
{
    [SerializeField]
    private float chanceOfEffect;

    [SerializeField]
    private Sprite effectSprite;

    [SerializeField]
    private effectsList effectType;

    [SerializeField]
    private float damageOfEffect;

    [SerializeField]
    private float timeOfEffect;

    public float ChanceOfEffect
    {
        get
        {
            return chanceOfEffect;
        }
    }

    public Sprite EffectSprite
    {
        get
        {
            return effectSprite;
        }
    }
    public effectsList EffectType
    {
        get
        {
            return effectType;
        }
    }
    public float DamageOfEffect
    {
        get
        {
            return damageOfEffect;
        }
    }
    public float TimeOfEffect
    {
        get
        {
            return timeOfEffect;
        }
    }

    public enum effectsList
    {
        Burning = 0,
        Poison = 1,
        Bleeding = 2,
        Stun = 3,
        Qurse = 4
    }
}


