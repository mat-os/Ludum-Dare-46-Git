using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New LevelData", menuName = "Level Data", order = 51)]
public class LevelData : ScriptableObject
{
    [SerializeField]
    private int stagesOnLevel;

    [SerializeField]
    private StageData[] possibleStages;

    [SerializeField]
    private bool isHaveBoss;

    [SerializeField]
    private StageData bosStageData;

    private StageData[] shuffledStages;

    public StageData[] PossibleStages
    {
        get
        {
            return possibleStages;
        }
    }

    public int StagesOnLevel
    {
        get
        {
            return stagesOnLevel;
        }
    }

    public StageData[] ShuffledStages
    {
        get
        {
            shuffledStages = possibleStages;
            RandomizeArray(shuffledStages);
            return shuffledStages;
        }
    }



    public static void RandomizeArray<T>(T[] array)
    {
        int size = array.Length;
        for (int i = 0; i < size; i++)
        {
            int indexToSwap = Random.Range(i, size);
            T swapValue = array[i];
            array[i] = array[indexToSwap];
            array[indexToSwap] = swapValue;
        }
    }
}
