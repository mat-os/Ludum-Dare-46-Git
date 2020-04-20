using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailUIController : MonoBehaviour
{
    public GameObject failUI;

    public void GameIsFailed()
    {
        failUI.SetActive(true);
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void ReloadButton()
    {
        SceneManager.LoadScene(1);
    }
}
