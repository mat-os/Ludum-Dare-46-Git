using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SpecialStageData", menuName = "SpecialStage Data", order = 51)]
public class SpecialStageData : ScriptableObject
{
    [SerializeField]
    private GameObject objectToSpawn;

    public GameObject ObjectToSpawn
    {
        get
        {
            return objectToSpawn;
        }
    }

}
