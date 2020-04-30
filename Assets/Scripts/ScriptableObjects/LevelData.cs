using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New LevelData", menuName = "Level Data", order = 51)]
public class LevelData : ScriptableObject
{
    [SerializeField]
    private int stagesWithEnemyOnLevel;

    [SerializeField]
    private List<StageData> possibleStages = new List<StageData>();

    [SerializeField]
    private int specialStagesOnLevel;

    [SerializeField]
    private List<SpecialStageData> possibleSpectialStages = new List<SpecialStageData>();
    
    [SerializeField]
    private bool isHaveBoss;

    [SerializeField]
    private StageData bosStageData;


    public int StagesWithEnemyOnLevel
    {
        get
        {
            return stagesWithEnemyOnLevel;
        }
    }

    public int SpecialStagesOnLevel
    {
        get
        {
            return specialStagesOnLevel;
        }
    }
    public List<StageData> PossibleStages
    {
        get
        {
            return possibleStages;
        }
    }

    public List<SpecialStageData> PossibleSpectialStages
    {
        get
        {
            return possibleSpectialStages;
        }
    }
}

