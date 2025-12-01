using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class TitleButton : MonoBehaviour
{
    public string SceneToLoad;
    
    public void LoadGame()
    {
        SceneManager.LoadScene(SceneToLoad);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}