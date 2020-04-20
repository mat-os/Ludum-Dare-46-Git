using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private bool isHaveSave;

    public GameObject loadingScreen;
    public Slider slider;

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        StartCoroutine(ExitGameRoutine());

    }

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsync(sceneIndex));
    }

    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        
        loadingScreen.SetActive(true);
        
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progress;
            
            yield return null;
        }
    }

    IEnumerator ExitGameRoutine()
    {
        yield return  new WaitForSeconds(0.8f);
        
        Application.Quit();
    }
}
