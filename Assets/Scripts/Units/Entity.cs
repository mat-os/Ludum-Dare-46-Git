using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    private bool isAlive = true;

    public bool GetIsAlive()
    {
        return isAlive;
    }

    public void SetIsAlive(bool newBool)
    {
        isAlive = newBool;
    }

    public abstract void Initialisation(float _minDamage, float _maxDamage, float _attackRate, float _HPMax);

    public abstract void TakeDamage(float damageTaken);

    public abstract void Dead();


}
