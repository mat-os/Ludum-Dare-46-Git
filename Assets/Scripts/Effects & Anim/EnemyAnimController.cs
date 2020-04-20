using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyAnimController : MonoBehaviour
{
    public SpriteRenderer sr;

    void Start()
    {
        
    }

    public void DeadAnim()
    {
        sr.DOFade(0,0.5f);
    }
}
