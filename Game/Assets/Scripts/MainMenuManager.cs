using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public void quit()
    {
        Debug.Log("quitting");
        Application.Quit();
    }

    public void loadLevel(int levelID)
    {
        Debug.Log("loading level " + levelID);
        SceneManager.LoadScene(levelID, LoadSceneMode.Single);
    }
}
