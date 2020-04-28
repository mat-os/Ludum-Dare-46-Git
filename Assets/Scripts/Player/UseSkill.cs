using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseSkill : MonoBehaviour
{
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private SkillPanelControll skillPanelControll;
    [SerializeField] private HandAnimationController handAnimationController;

    private ManaController manaController;

    void Start()
    {
        manaController = GameInstance.Instance.manaController;
    }

    public void UseSkillFromInventory(int ButtonNumber)
    {
        if (inventory.GetSkill(ButtonNumber).GetIsSkillPassive() != true)
        {
            if (inventory.GetSkill(ButtonNumber).GetIsSkillReady())
            {
                inventory.GetSkill(ButtonNumber).UseSkill();
                CountCooldown(ButtonNumber - 1);
                handAnimationController.PlayHandAnim(ButtonNumber);

                GameInstance.Instance.manaController.SpendMana(inventory.GetSkill(ButtonNumber).GetManacost());
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && inventory.GetSkill(1) != null)
        {
            UseSkillFromInventory(1);
        }

        else if (Input.GetKeyDown(KeyCode.W) && inventory.GetSkill(2) != null)
        {
            UseSkillFromInventory(2);
        }

        else if(Input.GetKeyDown(KeyCode.E) && inventory.GetSkill(3) != null)
        {
            UseSkillFromInventory(3);
        }

        else if(Input.GetKeyDown(KeyCode.R) && inventory.GetSkill(5) != null)
        {
            UseSkillFromInventory(4);
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
