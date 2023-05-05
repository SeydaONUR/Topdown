using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayExit : MonoBehaviour
{
    public string sceneName;

    public void ExitGame()
{
    Application.Quit();
}
    public void nextGame()
    {
        SceneManager.LoadScene(sceneName);
    }

}
