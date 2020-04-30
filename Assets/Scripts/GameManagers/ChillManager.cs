using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChillManager : MonoBehaviour
{
    public GameObject Altar;

    public GameObject NewSkillUI;

    public void ActivateSkill()
    {
        NewSkillUI.SetActive(false);

        Altar.SetActive(false);

        GameInstance.Instance.gameplayController.WalkAndSearch();

        GameInstance.Instance.manaController.RestoreAllMana();
    }

    public void StartChill()
    {
        StartCoroutine(StartChillRoutine());
    }

    IEnumerator StartChillRoutine()
    {
        ShowAltar();

        yield return new WaitForSeconds(3.5f);

        ShowNewSkillUI();
    }

    private void ShowAltar()
    {
        Altar.SetActive(true);
    }

    private void ShowNewSkillUI()
    {
        NewSkillUI.SetActive(true);
    }


}
