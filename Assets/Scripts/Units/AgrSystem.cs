using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgrSystem : MonoBehaviour
{
    public float agrTime;

    private Human human;

    private bool isUsedAgr;

    //private HPBarManager hpBarManager;

    void Start()
    {
        human = GetComponent<Human>();

        //hpBarManager = GetComponent<HPBarManager>();
    }

    public void UseAgr()
    {
        foreach (var a in human.Enemies)
        {
            for (int i = 0; i < human.Enemies.Count; i++)
            {
                a.Agred(human, agrTime);
            }
        }
    }
}
