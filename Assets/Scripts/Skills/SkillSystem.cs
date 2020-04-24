using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSystem : MonoBehaviour
{
    //0 - стартовые скилы

    public List<Skill[]> SkillsList = new List<Skill[]>();


    [SerializeField] private Skill[] startSkills;

    [SerializeField] private Skill[] skillsLevel1;
    [SerializeField] private Skill[] skillsLevel2;
    [SerializeField] private Skill[] skillsLevel3;
    [SerializeField] private Skill[] passiveSkills;
    [SerializeField] private Skill[] skillsLevel4;

    void Start()
    {
        SkillsList.Add(startSkills);
    }

    public Skill getStartSkills(int SkillNumber)
    {
        return startSkills[SkillNumber];
    }

    public Skill GetRandomSkillOfLevel(int level)
    {
        switch (level)
        {
            case 1:
                return skillsLevel1[generateRandomNumber(0, skillsLevel1.Length)];
            case 2:
                return skillsLevel2[generateRandomNumber(0, skillsLevel2.Length)];
            case 3:
                return skillsLevel3[generateRandomNumber(0, skillsLevel3.Length)];
            case 4:
                return passiveSkills[generateRandomNumber(0, passiveSkills.Length)];
            case 5:
                return skillsLevel4[generateRandomNumber(0, skillsLevel4.Length)];
        }

        return null;
    }



    private static int lastRandomNumber;

    public static int generateRandomNumber(int min, int max)
    {

        int result = Random.Range(min, max);

        if (result == lastRandomNumber)
        {

            return generateRandomNumber(min, max);

        }

        lastRandomNumber = result;
        return result;

    }
}
