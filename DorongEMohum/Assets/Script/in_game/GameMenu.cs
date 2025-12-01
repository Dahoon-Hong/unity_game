using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public string TitleScene;
    public string CurrentScene;
    public GameObject gameoverPanel;
    public AudioSource bgm;

    // Start is called before the first frame update
    void Start()
    {
        gameoverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // 게임오버 처리
        if (gameoverPanel.activeSelf)
        {
            // if (Input.GetKeyDown("r"))
            // {
            //     SceneManager.LoadScene(0);
            // }
            
        }
    }
    public void GameOver()
    {
        gameoverPanel.SetActive(true);
        bgm.Stop();
        Debug.Log("STOP");
    }
        
    public void Retry()
    {
        SceneManager.LoadScene(CurrentScene);
    }

    public void Exit()
    {
        SceneManager.LoadScene(TitleScene);
    }
}
