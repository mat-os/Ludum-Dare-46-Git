﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShildHPBarManager : MonoBehaviour
{
    public GameObject shield;

    public void ActivateShield()
    {
        shield.SetActive(true);
    }

    public void DectivateShield()
    {
        shield.SetActive(false);
    }
}