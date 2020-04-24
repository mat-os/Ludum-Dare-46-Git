using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseSkill : MonoBehaviour
{
    [SerializeField] private PlayerInventory inventory;

    public void UseSkillFromInventory(int ButtonNumber)
    {
        inventory.GetSkill(ButtonNumber).UseSkill();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            inventory.GetSkill(1).UseSkill();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            inventory.GetSkill(2).UseSkill();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            inventory.GetSkill(3).UseSkill();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            inventory.GetSkill(4).UseSkill();
        }
    }
}
