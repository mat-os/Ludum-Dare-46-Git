using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpecialRoom : MonoBehaviour
{
    public void SpawnRoom(SpecialStageData specialStage)
    {
        GameObject currentStageObj = Instantiate(specialStage.ObjectToSpawn,transform.position, Quaternion.identity);

        currentStageObj.name = specialStage.ObjectToSpawn.name;

        GameInstance.Instance.gameplayController.OnSpecialRoomEvent();



        Debug.Log("SpawnSpecialRoom");

    }
}
