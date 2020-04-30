using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

public class Test : MonoBehaviour
{
    public BuffableEntity buffableEntity;

    public ScriptableSpeedBuff speedBuff;

    // Start is called before the first frame update
    void Start()
    {
        buffableEntity.AddBuff(speedBuff.InitializeBuff(buffableEntity.gameObject));
    }


}
