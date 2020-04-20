using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New LevelData", menuName = "Level Data", order = 51)]
public class LevelData : ScriptableObject
{
    [SerializeField]
    private StageData[] stagesOnLevel;

    public StageData[] StagesOnLevel
    {
        get
        {
            return stagesOnLevel;
        }
    }
}
