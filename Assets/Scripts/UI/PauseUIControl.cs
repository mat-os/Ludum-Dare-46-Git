using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUIControl : MonoBehaviour
{
    public GameObject pauseUI;
    private bool isPause = false;

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            PauseMenuSet(isPause);
        }
    }

    public void PauseMenuSet(bool isEnable)
    {
        switch (isEnable)
        {
            case true:
                pauseUI.SetActive(false);
                isPause = false;

                Time.timeScale = 1;
                break;

            case false:
                pauseUI.SetActive(true);
                isPause = true;

                Time.timeScale = 0;
                break;
        }
    }

    public void LoadMenu()
    {
        PauseMenuSet(true);
        
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        PauseMenuSet(true);
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
