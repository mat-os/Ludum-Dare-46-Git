using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseSkill : MonoBehaviour
{
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private SkillPanelControll skillPanelControll;

    public void UseSkillFromInventory(int ButtonNumber)
    {
        inventory.GetSkill(ButtonNumber).UseSkill();
        CountCooldown(ButtonNumber - 1);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && inventory.GetSkill(1) != null)
        {
            inventory.GetSkill(1).UseSkill();
            CountCooldown(1);
        }

        if (Input.GetKeyDown(KeyCode.W) && inventory.GetSkill(2) != null)
        {
            inventory.GetSkill(2).UseSkill();
            CountCooldown(2);

        }

        if (Input.GetKeyDown(KeyCode.E) && inventory.GetSkill(3) != null)
        {
            inventory.GetSkill(3).UseSkill();
            CountCooldown(3);

        }

        if (Input.GetKeyDown(KeyCode.R) && inventory.GetSkill(4) != null)
        {
            inventory.GetSkill(4).UseSkill();
            CountCooldown(4);

        }
    }

    public void CountCooldown(int _skillNumber)
    {
        StartCoroutine(countCooldownRoutine(_skillNumber));
    }

    IEnumerator countCooldownRoutine(int _skillNumber)
    {
        skillPanelControll.TurnOffSkill(_skillNumber);

        yield return new WaitForSeconds(inventory.GetSkill(_skillNumber + 1).GetSkillCooldownTime());

        skillPanelControll.TurnOnSkill(_skillNumber);
    }

}
