using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChillManager : MonoBehaviour
{
    public GameObject Altar;

    public void ShowAltar()
    {
        Altar.SetActive(true);
    }
}
